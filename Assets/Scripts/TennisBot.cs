using UnityEngine;

[RequireComponent(typeof(TennisRacket))]
public class TennisBot : MonoBehaviour
{
    public GameObject FocusedBall;

    private TennisRacket _tennisRacket;

    private void Start()
    {
        _tennisRacket = GetComponent<TennisRacket>();
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(
            transform.position.x,
            FocusedBall.transform.position.y,
            FocusedBall.transform.position.z
        );

        _tennisRacket.Move(newPosition);
    }
}