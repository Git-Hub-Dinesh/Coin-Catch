using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase score through GameManager or UI Manager
            GameManager.Instance.AddScore(1);

            // Destroy coin
            Destroy(gameObject);
        }
    }
}
