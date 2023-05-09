//using System.Collections;
//using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
//public class TennisBallSoundHandler : MonoBehaviour
//{
//    [SerializeField] private AudioClip defaulthitSound;
//    [SerializeField] private AudioClip racketHitSound;

//    private AudioSource _audioSource;
//    private bool _canPlaySound = true;

//    private void Start()
//    {
//        _audioSource = GetComponent<AudioSource>();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (_canPlaySound)
//        {
//            float pitch = Random.Range(0.9f, 1.1f);
//            _audioSource.pitch = pitch;
//            //if (collision.gameObject.)  
//            {
//                _audioSource.PlayOneShot(racketHitSound);
//            }
//            else
//            {
//                _audioSource.Play();
//                _canPlaySound = false;
//                StartCoroutine(KickSoundCooldown());
//            }
//        }

//    }

//    IEnumerator KickSoundCooldown()
//    {
//        yield return new WaitForSeconds(0.15f);
//        _canPlaySound = true;
//    }
//}