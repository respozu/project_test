using UnityEngine;

[RequireComponent(typeof(TennisRacket))]
public class RacketPlayer : MonoBehaviour
{
    private TennisRacket _racket;
    
    private void Start()
    {
        _racket = GetComponent<TennisRacket>();
    }

    private void FixedUpdate()
    {
        Vector3 cameraInput = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        
        Vector3 newPosition = new Vector3(transform.position.x, cameraInput.y, cameraInput.z);
        
        _racket.Move(newPosition);
    }
}