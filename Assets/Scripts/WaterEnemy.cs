using UnityEngine;
using UnityEngine.SceneManagement;
// Attach to Water object (optional)
public class WaterHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Playermovement>().TakeWaterDamage(); // Custom method
        }
    }
}
