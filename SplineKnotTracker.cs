using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Splines;

public class SplineKnotTracker : MonoBehaviour
{
    public CinemachineSplineDolly dolly;
    public int currentKnot;

    void Update()
    {
        // Check if dolly and the spline container are assigned
        if (dolly != null && dolly.Spline != null)
        {
            // Access the first spline in the container and count its knots
            int knotCount = dolly.Spline.Splines[0].Count;

            // Calculate which knot we are closest to (0 to 1 range)
            float rawIndex = dolly.CameraPosition * (knotCount - 1);
            int nearestKnot = Mathf.RoundToInt(rawIndex);

            if (nearestKnot != currentKnot)
            {
                currentKnot = nearestKnot;
                Debug.Log("<color=yellow>Inspection Point:</color> You are now at <b>Knot " + currentKnot + "</b>");
            }
        }
    }
}