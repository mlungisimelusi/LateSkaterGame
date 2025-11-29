using UnityEngine;

public class PaperMover : MonoBehaviour
{
    public float speed = 2f;
    public float floatAmplitude = 0.3f;
    public float floatFrequency = 2f;
    public float rotationSpeed = 30f;

    private Vector3 startPosition;
    private float screenLeft = -12f;
    private float screenRight = 12f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move paper to the left (right → left)
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Flutter up/down
        float floatY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + floatY, transform.position.z);

        // Rotate gently
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Loop the paper when it goes off-screen left
        if (transform.position.x < screenLeft)
        {
            float newY = Random.Range(-2f, 2f); // New flutter height
            transform.position = new Vector3(screenRight, newY, 0f); // Wrap to the right
            startPosition.y = newY; // Reset float origin
        }
    }
}



