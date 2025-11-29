using UnityEngine;

public class DogRunnerController : MonoBehaviour
{
    public float runSpeed = 2f;
    public string standTrigger = "Stand";
    public string runTrigger = "Run";

    private Rigidbody2D rb;
    private Animator animator;
    private bool isRunning = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartRunning();
    }

    void Update()
    {
        if (isRunning)
            rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DogObstacle"))
        {
            StopRunning();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DogObstacle"))
        {
            StartRunning();
        }
    }

    void StartRunning()
    {
        isRunning = true;
        animator.ResetTrigger(standTrigger);
        animator.SetTrigger(runTrigger);
    }

    void StopRunning()
    {
        isRunning = false;
        animator.ResetTrigger(runTrigger);
        animator.SetTrigger(standTrigger);
    }
}
