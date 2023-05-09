using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TennisRacket : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;
    
    [SerializeField] private Vector2 xRotationBorders;
    [SerializeField] private Vector2 yRotationBorders;
    [SerializeField] private Vector2 zRotationBorders;

    private Vector3 _startRot;
    
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        _startRot = transform.eulerAngles;
    }

    public void Move(Vector3 newPos)
    {
        Quaternion newRotation = Quaternion.Euler(
            Mathf.Clamp(_startRot.x + -newPos.z * rotationSpeed.x, xRotationBorders.x, xRotationBorders.y),
            Mathf.Clamp(_startRot.y + -newPos.z * rotationSpeed.y, yRotationBorders.x, yRotationBorders.y),  
            Mathf.Clamp(_startRot.z + newPos.y * rotationSpeed.z, zRotationBorders.x, zRotationBorders.y));
        _rb.Move(newPos, newRotation);
    }
}