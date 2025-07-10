using UnityEngine;

public class MoceMovement : MonoBehaviour
{
    [SerializeField] private Transform player; // Drag your player here in the Inspector
    [SerializeField] private float activationDistance = 5f;

    private Rigidbody2D rb;
    private bool hasActivated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false; // Turn off physics initially
    }

    void Update()
    {
        if (!hasActivated && Vector2.Distance(transform.position, player.position) <= activationDistance)
        {
            rb.simulated = true;
            hasActivated = true; // Prevents reactivation
        }
    }
}
