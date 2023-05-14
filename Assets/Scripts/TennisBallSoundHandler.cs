using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TennisBallSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip defaultHitSound;

    [SerializeField] private Vector2 defaultKickSoundPitchRandom;
    [SerializeField] private Vector2 racketKickSoundPitchRandom;

    [SerializeField] private float kickSoundCooldowm;

    private AudioSource _audioSource;
    private bool _canPlaySound = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_canPlaySound) return;
        
        float pitch = Random.Range(defaultKickSoundPitchRandom.x, defaultKickSoundPitchRandom.y);
        _audioSource.pitch = pitch;
        
        if (collision.gameObject.TryGetComponent<TennisRacket>(out TennisRacket racket))
        {
            pitch = Random.Range(racketKickSoundPitchRandom.x, racketKickSoundPitchRandom.y);
            _audioSource.pitch = pitch;
            _audioSource.PlayOneShot(defaultHitSound);
        }
        else
        {
            _audioSource.PlayOneShot(defaultHitSound);
        }

        _canPlaySound = false;
        StartCoroutine(KickSoundCooldown());
    }

    IEnumerator KickSoundCooldown()
    {
        yield return new WaitForSeconds(kickSoundCooldowm);
        _canPlaySound = true;
    }
}