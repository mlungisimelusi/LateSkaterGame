//using UnityEngine;
//using TMPro;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class PlayerJump : MonoBehaviour
//{
//    public float jumpForce = 5f;
//    public TextMeshProUGUI gameOverText;

//    private Rigidbody2D rb;
//    private Animator animator;

//    private bool isAlive = true;
//    private bool isGameStarted = false;

//    private bool isGrounded = true;
//    private bool isFalling = false;
//    private bool isGameOver = false;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();

//        if (gameOverText != null)
//            gameOverText.gameObject.SetActive(false);
//    }

//    void Update()
//    {
//        // Start game on any key
//        if (!isGameStarted && Input.anyKeyDown)
//        {
//            StartGame();
//        }
//        //if (!isAlive || !isGameStarted) return;
//        if (isFalling) return;

//        // Handle Jump
//        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
//        {
//            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//            animator.ResetTrigger("Jump");
//            animator.SetTrigger("Jump");
//            isGrounded = false;
//            animator.SetBool("isGrounded", false);
//        }

//        // Handle Crouch
//        if (Input.GetKeyDown(KeyCode.DownArrow))
//        {
//            animator.SetBool("isCrouching", true);
//        }

//        if (Input.GetKeyUp(KeyCode.DownArrow))
//        {
//            animator.SetBool("isCrouching", false);
//        }

//        // Restart game if Game Over
//        if (isGameOver && Input.GetKeyDown(KeyCode.R))
//        {
//            Debug.Log("R pressed - Restarting...");
//            Time.timeScale = 1f;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//            animator.SetBool("isGrounded", true);
//        }
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Hole") && !isFalling)
//        {
//            StartCoroutine(SmoothFall());
//        }
//    }

//    IEnumerator SmoothFall()
//    {
//        isFalling = true;
//        rb.linearVelocity = Vector2.zero;
//       GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
//       GetComponent<Collider2D>().enabled = false;

//        if (animator != null)
//            animator.SetTrigger("isFalling");

//        float fallSpeed = 2f;
//        float duration = 1.5f;
//        float elapsed = 0f;

//        while (elapsed < duration)
//        {
//            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
//            elapsed += Time.deltaTime;
//            yield return null;
//        }

//        // Wait before enabling Game Over and freezing time
//        //StartCoroutine(ShowGameOverText());
//        GameManager.Instance.GameOver();
//    }

//    IEnumerator ShowGameOverText()
//    {
//        if (gameOverText != null)
//            gameOverText.gameObject.SetActive(true);

//        yield return new WaitForSecondsRealtime(0.2f); // Small delay to ensure input still works

//        isGameOver = true;
//        Time.timeScale = 0f;
//    }
//    void StartGame()
//    {
//        isGameStarted = true;
//        rb.gravityScale = 2; // Enable gravity when game starts

//        GameManager.Instance?.StartGame(); // Safe call
//    }
//    void Awake()
//    {
//        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
//        if (objs.Length > 1)
//        {
//            Destroy(this.gameObject);
//            return;
//        }

//        //DontDestroyOnLoad(this.gameObject); // Only keep the first instance
//    }

//}

//using UnityEngine;
//public class PlayerJump : MonoBehaviour
//{
//    public float jumpForce = 5f;
//    public float moveSpeed = 0.5f;

//    private Rigidbody2D rb;
//    private Animator animator;
//    private bool isGrounded = true;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
//        {
//            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//            animator.ResetTrigger("Jump");
//            animator.SetTrigger("Jump");
//            isGrounded = false;
//            animator.SetBool("isGrounded", false);
//        }

//        if (Input.GetKeyDown(KeyCode.DownArrow))
//        {
//            animator.SetBool("isCrouching", true);
//        }

//        if (Input.GetKeyUp(KeyCode.DownArrow))
//        {
//            animator.SetBool("isCrouching", false);
//        }
//    }

//    void FixedUpdate()
//    {
//        Vector2 velocity = rb.linearVelocity;
//        velocity.x = moveSpeed;
//        rb.linearVelocity = velocity;
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//            animator.SetBool("isGrounded", true);
//        }
//    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = false;
//            animator.SetBool("isGrounded", false);
//        }
//    }
//}
//////////////////////////////////////////////////////
//using UnityEngine;
//using TMPro;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class PlayerJump : MonoBehaviour
//{
//    public float jumpForce = 5f;
//    public float moveSpeed = 0.5f;
//    public TextMeshProUGUI gameOverText;

//    private Rigidbody2D rb;
//    private Animator animator;

//    private bool isAlive = true;
//    private bool isGameStarted = false;
//    private bool isGrounded = true;
//    private bool isFalling = false;
//    private bool isGameOver = false;

//    void Awake()
//    {
//        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
//        if (objs.Length > 1)
//        {
//            Destroy(this.gameObject);
//            return;
//        }
//    }

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();

//        if (gameOverText != null)
//            gameOverText.gameObject.SetActive(false);
//    }

//    void Update()
//    {
//        if (!isGameStarted && Input.anyKeyDown)
//        {
//            StartGame();
//        }

//        if (!isGameStarted || isFalling)
//            return;

//        // Handle Jump
//        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
//        {
//            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//            animator.ResetTrigger("Jump");
//            animator.SetTrigger("Jump");
//            isGrounded = false;
//            animator.SetBool("isGrounded", false);
//        }

//        // Handle Crouch
//        if (Input.GetKeyDown(KeyCode.DownArrow))
//        {
//            animator.SetBool("isCrouching", true);
//        }

//        if (Input.GetKeyUp(KeyCode.DownArrow))
//        {
//            animator.SetBool("isCrouching", false);
//        }

//        // Restart game
//        if (isGameOver && Input.GetKeyDown(KeyCode.R))
//        {
//            Debug.Log("R pressed - Restarting...");
//            Time.timeScale = 1f;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//    void FixedUpdate()
//    {
//        if (!isGameStarted || isFalling)
//            return;

//        Vector2 velocity = rb.linearVelocity;
//        velocity.x = moveSpeed;
//        rb.linearVelocity = velocity;
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//            animator.SetBool("isGrounded", true);
//        }
//    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = false;
//            animator.SetBool("isGrounded", false);
//        }
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Hole") && !isFalling)
//        {
//            StartCoroutine(SmoothFall());
//        }
//    }

//    IEnumerator SmoothFall()
//    {
//        isFalling = true;
//        rb.linearVelocity = Vector2.zero;
//        rb.bodyType = RigidbodyType2D.Dynamic;
//        GetComponent<Collider2D>().enabled = false;

//        if (animator != null)
//            animator.SetTrigger("isFalling");

//        float fallSpeed = 2f;
//        float duration = 1.5f;
//        float elapsed = 0f;

//        while (elapsed < duration)
//        {
//            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
//            elapsed += Time.deltaTime;
//            yield return null;
//        }

//        GameManager.Instance.GameOver(); // Ends the game
//    }

//    void StartGame()
//    {
//        isGameStarted = true;
//        rb.gravityScale = 2; // Enable gravity
//        GameManager.Instance?.StartGame(); // Call game manager
//    }
//}


using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float baseSpeed = 0.5f; // renamed from moveSpeed
    public float speedGrowthPerLevel = 0.2f;
    public TextMeshProUGUI gameOverText;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isAlive = true;
    private bool isGameStarted = false;
    private bool isGrounded = true;
    private bool isFalling = false;
    private bool isGameOver = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameStarted && Input.anyKeyDown)
        {
            StartGame();
        }

        if (!isGameStarted || isFalling)
            return;

        // Handle Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.ResetTrigger("Jump");
            animator.SetTrigger("Jump");
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }

        // Handle Crouch
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("isCrouching", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("isCrouching", false);
        }

        // Restart game
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed - Restarting...");
            Time.timeScale = 1f;
            LevelEndZone.level = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        if (!isGameStarted || isFalling)
            return;

        int level = LevelEndZone.level; // make sure LevelEndZone.level is a public static int
        float levelMultiplier = 1f + (level - 1) * speedGrowthPerLevel;
        float currentSpeed = baseSpeed * levelMultiplier;

        Vector2 velocity = rb.linearVelocity;
        velocity.x = currentSpeed;
        rb.linearVelocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole") && !isFalling)
        {
            StartCoroutine(SmoothFall());
        }
    }

    IEnumerator SmoothFall()
    {
        isFalling = true;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = false;

        if (animator != null)
            animator.SetTrigger("isFalling");

        float fallSpeed = 2f;
        float duration = 1.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }

        GameManager.Instance.GameOver(); // Ends the game
        LevelEndZone.level = 1;
    }

    void StartGame()
    {
        isGameStarted = true;
        rb.gravityScale = 2; // Enable gravity
        GameManager.Instance?.StartGame(); // Call game manager
    }
}





















