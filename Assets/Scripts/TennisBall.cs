using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TennisBall : MonoBehaviour
{
    [SerializeField] private PhysicMaterial leftSide;
    [SerializeField] private PhysicMaterial rightSide;

    [SerializeField] private AudioClip defaultHitSound;

    [SerializeField] private Vector2 defaultKickSoundPitchRandom;
    [SerializeField] private Vector2 racketKickSoundPitchRandom;

    [SerializeField] private float kickSoundCooldown;

    private AudioSource _audioSource;
    private bool _canPlaySound = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<TennisTable>(out TennisTable table))
        {
            if (other.collider.sharedMaterial == leftSide) table.OnBallTouched(TableSide.Left);
            else if (other.collider.sharedMaterial == rightSide) table.OnBallTouched(TableSide.Right);
            else Debug.LogError("Ball touched table, but no side assigned.");
        }

        if (!_canPlaySound) return;

        float pitch = Random.Range(defaultKickSoundPitchRandom.x, defaultKickSoundPitchRandom.y);
        _audioSource.pitch = pitch;

        if (other.gameObject.TryGetComponent<TennisRacket>(out TennisRacket racket))
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

    private IEnumerator KickSoundCooldown()
    {
        yield return new WaitForSeconds(kickSoundCooldown);
        _canPlaySound = true;
    }
}