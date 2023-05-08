using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TennisBallSoundHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float pitch = Random.Range(0.9f, 1.1f);
        _audioSource.pitch = pitch;
        _audioSource.Play();
    }
}


