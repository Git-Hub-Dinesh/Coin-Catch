using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverManager manager = FindObjectOfType<GameOverManager>();
            if (manager != null)
            {
                manager.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint reached: " + transform.position);
            }
        }
    }
}
