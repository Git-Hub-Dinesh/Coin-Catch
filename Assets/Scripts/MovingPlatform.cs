using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 2.5f;     // Move ±2.5 units from start
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= startPosition.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - moveDistance)
                movingRight = true;
        }
    }

    // Stick player to platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
