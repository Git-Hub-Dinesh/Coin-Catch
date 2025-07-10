using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] Transform target;        // Player transform
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;          // Camera offset

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z); // Lock z
    }
}
