using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip coinSound;

    private bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;

            PlayCoinSound();

            // Disable visuals and collider immediately
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Destroy after short delay to give time for sound cleanup
            Destroy(gameObject, 0.1f);
        }
    }

    void PlayCoinSound()
    {
        GameObject tempSound = new GameObject("CoinSound");
        AudioSource audioSource = tempSound.AddComponent<AudioSource>();
        audioSource.clip = coinSound;
        audioSource.Play();

        // Destroy the temp object after sound finishes
        Destroy(tempSound, coinSound.length);
    }
}
