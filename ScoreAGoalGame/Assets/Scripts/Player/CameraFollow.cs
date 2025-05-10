using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -6);
    public float rotationSpeed = 3f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 15f;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
