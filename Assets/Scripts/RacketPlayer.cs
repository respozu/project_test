using UnityEngine;

[RequireComponent(typeof(TennisRacket))]
public class RacketPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;
    
    [SerializeField] private Vector2 xRotationBorders;
    [SerializeField] private Vector2 yRotationBorders;
    [SerializeField] private Vector2 zRotationBorders;
    
    private TennisRacket _racket;

    private Vector3 _startPos;
    private Vector3 _startRot;
    
    private void Start()
    {
        _racket = GetComponent<TennisRacket>();

        _startPos = transform.position;
        _startRot = transform.eulerAngles;
    }

    private void FixedUpdate()
    {
        Vector3 cameraInput = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        
        Vector3 newPosition = new Vector3(transform.position.x, cameraInput.y, cameraInput.z);

        Quaternion newRotation = Quaternion.Euler(
            Mathf.Clamp(_startRot.x + -newPosition.z * rotationSpeed.x, xRotationBorders.x, xRotationBorders.y),
            Mathf.Clamp(_startRot.y + -newPosition.z * rotationSpeed.y, yRotationBorders.x, yRotationBorders.y),  
            Mathf.Clamp(_startRot.z + newPosition.y * rotationSpeed.z, zRotationBorders.x, zRotationBorders.y));
        
        _racket.Move(newPosition, newRotation);
    }
}