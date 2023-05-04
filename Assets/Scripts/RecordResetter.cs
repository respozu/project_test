using UnityEngine;

public class RecordResetter : MonoBehaviour
{
    [SerializeField] private RecordCounter _rocket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TennisBall"))
        {
            _rocket.ResetScore();
        }
    }
}

