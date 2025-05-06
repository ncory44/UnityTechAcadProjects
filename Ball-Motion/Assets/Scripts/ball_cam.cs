using UnityEngine;

public class ball_cam : MonoBehaviour
{
    public Transform sphere; // assign sphere in inspector
    public Vector3 offset;   // camera offset from sphere
    public float smoothSpeed = 0.125f; // smoothing factor

    void LateUpdate()
    {
        Vector3 desiredPosition = sphere.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(sphere);
    }
}
