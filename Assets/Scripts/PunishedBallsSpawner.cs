using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class PunishedBallsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float punishForce;
    [SerializeField] private float ballLifeTime;
    [SerializeField] private float punishRandomCoefficient;

    private void Start()
    {
        StartCoroutine(StartSpawnBalls());
    }

    private IEnumerator StartSpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCooldown);
            var ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            ball.AddComponent<ObjectDestroyer>().DestroyAfterTime(ballLifeTime);

            if (ball.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                Vector3 directionRandomizer = new Vector3(
                    Random.Range(-punishRandomCoefficient, punishRandomCoefficient),
                    Random.Range(-punishRandomCoefficient, punishRandomCoefficient),
                    Random.Range(-punishRandomCoefficient, punishRandomCoefficient));
                rb.AddForce((ball.transform.forward + directionRandomizer) * punishForce);
            }
        }
    }
}
