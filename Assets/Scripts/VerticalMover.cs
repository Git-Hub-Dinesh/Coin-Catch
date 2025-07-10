using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    public float moveDistance = 0.5f;  // Move ±0.5 on Y-axis
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + moveDistance)
                movingUp = false;
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - moveDistance)
                movingUp = true;
        }
    }
}
