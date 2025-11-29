using UnityEngine;

public class PotholeMover1 : MonoBehaviour
{
    public float speed = 2f;
    public float groundY = -1.1f;         // Match your ground's Y position
    private float screenLeft = -12f;
    private float screenRight = 12f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Keep pothole level with the ground
        transform.position = new Vector3(transform.position.x, groundY, transform.position.z);

        if (transform.position.x < screenLeft)
        {
            transform.position = new Vector3(screenRight, groundY, transform.position.z);
        }
    }

}

