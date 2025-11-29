using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target; // Drag the Player here in the Inspector

    [Header("Scene Bounds")]
    public Vector2 minBounds; // Set to left side of your level (e.g. -30.7)
    public Vector2 maxBounds; // Set to right side of your level (e.g. 32.5)

    [Header("Follow Settings")]
    public float smoothSpeed = 0.125f;

    private float cameraHalfWidth;

    void Start()
    {
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;
        cameraHalfWidth = camWidth;

        if (target != null)
        {
            float clampedX = Mathf.Clamp(target.position.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }


    void LateUpdate()
    {
        if (target == null) return;

        // Desired X follows the target, Y & Z stay the same
        Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);

        // Smoothly interpolate to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Clamp X to stay within level bounds
        float clampedX = Mathf.Clamp(smoothedPosition.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);

        // Set camera position
        transform.position = new Vector3(clampedX, smoothedPosition.y, smoothedPosition.z);
    }
}