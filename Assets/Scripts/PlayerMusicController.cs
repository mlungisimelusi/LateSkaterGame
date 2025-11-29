using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed = 5f;
    //public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public TextMeshProUGUI gameOverText;

    public AudioSource sfxSource;           // Plays jump, hit, coin, game over sounds
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip coinSound;
    public AudioClip gameOverSound;

    public AudioSource bgMusic;             // Plays background music

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);


    }

    void Update()
    {
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (animator != null)
                animator.Play("Jump");

            if (sfxSource != null && jumpSound != null)
                sfxSource.PlayOneShot(jumpSound);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            if (sfxSource != null && gameOverSound != null)
                sfxSource.PlayOneShot(gameOverSound);

            if (bgMusic != null)
                bgMusic.Stop();

            //StartCoroutine(SmoothFall());
        }

        if (other.CompareTag("Newspaper"))
        {
            if (sfxSource != null && hitSound != null)
                sfxSource.PlayOneShot(hitSound);
        }

        if (other.CompareTag("Coin"))
        {
            if (sfxSource != null && coinSound != null)
                sfxSource.PlayOneShot(coinSound);
        }
    }

    //IEnumerator SmoothFall()
    //{
    //    rb.linearVelocity = Vector2.zero;
    //    rb.isKinematic = true;
    //    GetComponent<Collider2D>().enabled = false;

    //    if (animator != null)
    //        animator.Play("Fall");

    //    float fallSpeed = 10f;
    //    float duration = 1f;
    //    float elapsed = 0f;

    //    while (elapsed < duration)
    //    {
    //        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    //        elapsed += Time.deltaTime;
    //        yield return null;
    //    }

    //    if (gameOverText != null)
    //        gameOverText.gameObject.SetActive(true);

    //    Time.timeScale = 0f;
    //}

}