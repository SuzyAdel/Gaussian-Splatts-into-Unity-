using UnityEngine;
using Unity.Cinemachine;

public class DollyManualControl : MonoBehaviour
{
    // Drag your Cinemachine Camera here in the Inspector
    public CinemachineSplineDolly dolly; 
    
    // Adjust this to change how fast the arrows move the camera
    public float moveSpeed = 0.2f; 

    void Update()
    {
        if (dolly != null)
        {
            // Use Horizontal (Left/Right arrows) or Vertical (Up/Down arrows)
            float input = Input.GetAxis("Horizontal");

            // Move the camera along the 0 to 1 spline path
            dolly.CameraPosition += input * moveSpeed * Time.deltaTime;

            // Optional: This makes the camera loop back to the start if your spline is 'Closed'
            if (dolly.CameraPosition > 1f) dolly.CameraPosition = 0f;
            if (dolly.CameraPosition < 0f) dolly.CameraPosition = 1f;
        }
    }
}