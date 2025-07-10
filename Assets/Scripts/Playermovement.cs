using System;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Jump Settings")]
    public int maxJumps = 2;
    private int jumpCount;

    [Header("Ground Check")]
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundMask;

    [Header("Game Logic")]
    public GameOverManager gameOverManager;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isInvincible = false;
    private bool isGrounded = false;
    private float dirX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
        }

        HandleAnimation();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpCount++;
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask);

        if (isGrounded && rb.linearVelocity.y <= 0.01f)
        {
            jumpCount = 0;
        }
    }

    void HandleAnimation()
    {
        animator.SetBool("isRun", dirX != 0);
        animator.SetBool("isIdle", dirX == 0);

        if (dirX > 0) spriteRenderer.flipX = false;
        else if (dirX < 0) spriteRenderer.flipX = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            StartCoroutine(HandlePlayerHit());
        }
    }
    public void TakeWaterDamage()
{
    if (!isInvincible)
    {
        StartCoroutine(HandlePlayerHit());
    }
}


    System.Collections.IEnumerator HandlePlayerHit()
    {
        isInvincible = true;
        gameOverManager.PlayerHit();

        spriteRenderer.enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(1.2f);

        if (gameOverManager.HasLivesLeft())
        {
            transform.position = gameOverManager.GetRespawnPoint();
            gameOverManager.ResetAllFallingTraps();
            spriteRenderer.enabled = true;
            this.enabled = true;
        }

        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }

    internal bool IsInvincible()
    {
        throw new NotImplementedException();
    }
}
