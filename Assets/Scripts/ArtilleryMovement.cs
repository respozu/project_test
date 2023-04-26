using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArtilleryMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private PlayerInput _input;
    private Rigidbody _rb;

    private void Start()
    {
        _input = new PlayerInput();
        _rb = GetComponent<Rigidbody>();
        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Enable();
        Debug.Log("enable");
    }

    private void Update()
    {
        Vector2 direction = _input.Player.Move.ReadValue<Vector2>();
        //Debug.Log(direction);
        Move(direction);
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Move(Vector2 direction)
    {
        Vector3 fullDirection = new Vector3(direction.x, 0, direction.y);
        _rb.AddForce(fullDirection * movementSpeed);
    }
}