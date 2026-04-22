using UnityEngine;
using UnityEngine.Splines;
using System.IO;
using Unity.Mathematics;

public class ColmapSplineGenerator : MonoBehaviour
{
    [Header("Settings")]
    public string filePath = @"C:\Users\PC\Downloads\stonehenge-tutorial\data\colmap\images.txt";
    public float scaleFactor = 10f;

    [Header("Targeting")]
    public Transform cameraTarget; // The 0,0,0 object

    void Start()
    {
        GenerateFromColmap();
    }

    public void GenerateFromColmap()
    {
        if (!File.Exists(filePath)) return;

        var container = GetComponent<SplineContainer>();
        if (container == null) container = gameObject.AddComponent<SplineContainer>();

        var spline = container.Spline;
        spline.Clear(); // Clear old knots from previous files

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(' ');
            if (parts.Length < 10) continue;

            // Extract COLMAP Pose
            float qw = float.Parse(parts[1]);
            float qx = float.Parse(parts[2]);
            float qy = float.Parse(parts[3]);
            float qz = float.Parse(parts[4]);
            float tx = float.Parse(parts[5]);
            float ty = float.Parse(parts[6]);
            float tz = float.Parse(parts[7]);

            // Math: Convert Camera-to-World
            Quaternion rot = new Quaternion(qx, qy, qz, qw);
            Matrix4x4 m = Matrix4x4.Rotate(rot);
            Vector3 pos = -(m.transpose.MultiplyPoint3x4(new Vector3(tx, ty, tz)));

            // Convert to Unity Space (Swap Y and Z if needed, but usually just scale)
            Vector3 unityPos = new Vector3(pos.x, -pos.y, pos.z) * scaleFactor;

            spline.Add(new BezierKnot(unityPos));
        }
        Debug.Log("Generated " + spline.Count + " knots from COLMAP file.");
    }
}