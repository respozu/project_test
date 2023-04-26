using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private float _currentRotationY = 0;

    private PlayerInput _input;

    private void Start()
    {
        _input = new PlayerInput();
        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Update()
    {
        _currentRotationY += _input.Player.TowerRotation.ReadValue<float>() * Time.deltaTime * rotationSpeed;
        Debug.Log(_currentRotationY);
        transform.rotation = Quaternion.Euler(transform.localRotation.x, _currentRotationY, transform.localRotation.z);
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
