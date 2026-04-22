using UnityEngine;
using UnityEngine.Splines;
using Unity.Cinemachine;
using System.IO;
using System.Collections.Generic;
using System.Globalization; // <-- Added to fix the number explosion bug

public class ColmapPathTranslator : MonoBehaviour
{
    [Header("Data Settings")]
    public string filepath = @"C:\Users\PC\Downloads\stonehenge-tutorial\data\colmap\images.txt";
    public int skipFrames = 30;
    public float scaleMultiplier = 1.0f;

    [Header("Movement Settings")]
    public CinemachineSplineDolly dollyCamera;
    public float moveSpeed = 0.5f;

    void Start()
    {
        GeneratePath();
    }

    void GeneratePath()
    {
        SplineContainer container = GetComponent<SplineContainer>();
        Spline spline = container.Spline;
        spline.Clear();
        spline.Closed = false;

        if (!File.Exists(filepath))
        {
            Debug.LogError("File not found! Check your path.");
            return;
        }

        string[] lines = File.ReadAllLines(filepath);
        int validImageCount = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#") || string.IsNullOrWhiteSpace(lines[i])) continue;

            if (validImageCount % skipFrames == 0)
            {
                string[] parts = lines[i].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 8)
                {
                    try
                    {
                        float qw = float.Parse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float qx = float.Parse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float qy = float.Parse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float qz = float.Parse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float tx = float.Parse(parts[5], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float ty = float.Parse(parts[6], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float tz = float.Parse(parts[7], NumberStyles.Any, CultureInfo.InvariantCulture);

                        Quaternion rot = new Quaternion(qx, qy, qz, qw).normalized;
                        Matrix4x4 m = Matrix4x4.Rotate(rot);
                        Vector3 pos = -(m.transpose.MultiplyPoint3x4(new Vector3(tx, ty, tz)));

                        spline.Add(new BezierKnot(new Vector3(pos.x, -pos.y, pos.z) * scaleMultiplier));
                    }
                    catch { }
                }
            }

            validImageCount++;
            i++; // Skip the 2D pixel line
        }

        for (int k = 0; k < spline.Count; k++) spline.SetTangentMode(k, TangentMode.AutoSmooth);

        // ---> THE CRITICAL FIX <---
        // This tells the Cinemachine camera to physically lock onto the path we just built!
        if (dollyCamera != null)
        {
            dollyCamera.Spline = container;
        }

        Debug.Log("Success: Clean path created with " + spline.Count + " knots.");
    }

    void Update()
    {
        if (dollyCamera == null) return;

        float input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            float newPosition = dollyCamera.CameraPosition + (input * moveSpeed * Time.deltaTime);
            dollyCamera.CameraPosition = Mathf.Clamp(newPosition, 0f, 1f);
        }
    }
}