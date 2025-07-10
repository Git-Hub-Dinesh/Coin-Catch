using UnityEngine;

public class ChestPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase score through GameManager or UI Manager
            GameManager.Instance.AddScore(5);

            // Destroy coin
            Destroy(gameObject);
        }
    }
}
