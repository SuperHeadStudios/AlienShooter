using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;            // The target the camera will follow.
    public float smoothSpeed = 0.125f;  // The speed with which the camera will follow.
    public Vector3 offset;              // The offset at which the camera follows the target.
    public Vector3 velocity;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
