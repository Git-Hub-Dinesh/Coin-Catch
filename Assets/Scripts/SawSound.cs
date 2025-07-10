using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SawSound : MonoBehaviour
{
    public Transform player;
    public float maxVolume = 0.3f;
    public float minVolume = 0f;
    public float maxDistance = 10f;

    private AudioSource sawAudio;

    void Start()
    {
        sawAudio = GetComponent<AudioSource>();
        sawAudio.loop = true;
        sawAudio.playOnAwake = false;
        sawAudio.volume = 0f;
        sawAudio.Play();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        float volume = Mathf.Lerp(maxVolume, minVolume, distance / maxDistance);
        sawAudio.volume = Mathf.Clamp(volume, minVolume, maxVolume);
    }
}
