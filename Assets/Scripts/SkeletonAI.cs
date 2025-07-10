using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float moveSpeed = 2f;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private Vector3 startPosition;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            MoveToward(player.position);
        }
        else if (isChasing && Vector2.Distance(transform.position, startPosition) > 0.1f)
        {
            // Player gone, return to start
            MoveToward(startPosition);
        }
        else
        {
            // Idle
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("isWalking", false);
            isChasing = false;
        }
    }

    void MoveToward(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - transform.position).normalized;

        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        // Flip sprite
        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }

        animator.SetBool("isWalking", true);
    }
}
