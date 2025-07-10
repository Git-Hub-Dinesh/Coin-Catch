using UnityEngine;

public class ActivateRigidbodyOnPlayerProximity : MonoBehaviour
{
    public float activationRange = 5f;          // Distance at which to activate
    public Transform playerTransform;           // Reference to player
    private Rigidbody2D rb;
    private bool hasActivated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;  // Turn off physics initially
    }

    void Update()
    {
        if (!hasActivated && Vector2.Distance(transform.position, playerTransform.position) <= activationRange)
        {
            rb.simulated = true;
            hasActivated = true;
        }
    }
}
