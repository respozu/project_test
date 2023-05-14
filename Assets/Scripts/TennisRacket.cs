using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class TennisRacket : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;

    [SerializeField] private float xRotationRange;
    [SerializeField] private float yRotationRange;
    [SerializeField] private float zRotationRange;
    
    private Vector2 _xRotationBorders;
    private Vector2 _yRotationBorders;
    private Vector2 _zRotationBorders;

    private Vector3 _startPos;
    private Vector3 _startRot;
    
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _startPos = transform.localPosition;
        _startRot = transform.localEulerAngles;

        _xRotationBorders.x = _startRot.x - xRotationRange / 2;
        _xRotationBorders.y = _startRot.x + xRotationRange / 2;
        
        _yRotationBorders.x = _startRot.y - yRotationRange / 2;
        _yRotationBorders.y = _startRot.y + yRotationRange / 2;
        
        _zRotationBorders.x = _startRot.z - zRotationRange / 2;
        _zRotationBorders.y = _startRot.z + zRotationRange / 2;
    }

    public void Move(Vector3 newPos)
    {
        float newRotY = _startRot.y - newPos.z * rotationSpeed.y;

        if (_startPos.x < 0)
        {
            newRotY = _startRot.y + newPos.z * rotationSpeed.y;
        }
        
        Quaternion newRotation = Quaternion.Euler(
            Mathf.Clamp(_startRot.x + -newPos.y * rotationSpeed.x,_xRotationBorders.x, _xRotationBorders.y),
            Mathf.Clamp(newRotY,_yRotationBorders.x, _yRotationBorders.y),  
            Mathf.Clamp(_startRot.z + newPos.z * rotationSpeed.z, _zRotationBorders.x, _zRotationBorders.y));

        if (_startPos.x < 0)
        {
            
        }

        _rb.Move(newPos, newRotation);
    }
}