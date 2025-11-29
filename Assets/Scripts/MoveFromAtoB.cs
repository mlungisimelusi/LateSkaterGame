using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private bool movingToB = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        transform.position = pointA.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Determine the current target
        Vector3 target = movingToB ? pointB.position : pointA.position;

        // Move towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if reached the target
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            // Flip the sprite to look the other way
            Flip();
            movingToB = !movingToB;
        }
    }

    void Flip()
    {
        // Flip the sprite horizontally
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else
        {
            // Fallback: use local scale if no SpriteRenderer is found
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
