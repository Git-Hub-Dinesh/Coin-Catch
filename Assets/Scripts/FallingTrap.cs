using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public float activationRange = 5f;
    public Transform player;

    private Rigidbody2D rb;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        ResetTrapPosition();
    }

    void Update()
    {
        if (!isFalling && Vector2.Distance(player.position, transform.position) <= activationRange)
        {
            ActivateTrap();
        }
    }

    void ActivateTrap()
    {
        isFalling = true;
        rb.simulated = true;
    }

    public void ResetTrapPosition()
    {
        isFalling = false;

        rb.simulated = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
