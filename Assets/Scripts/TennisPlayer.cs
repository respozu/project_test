using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisPlayer : MonoBehaviour
{
    [SerializeField] private GameObject directionPoint;

    [SerializeField] private float rotationSpeed;

    private PlayerInput _input;

    private float _startXPos;
    private float _startZRot;

    private void Start()
    {
        _input = new PlayerInput();
        _input.Player.Click.performed += context => Kick();
        _startXPos = transform.position.x;
        _startZRot = transform.eulerAngles.z;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Update()
    {
        Vector3 racketNewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 1));
        transform.position = racketNewPosition;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, racketNewPosition.z * rotationSpeed + _startZRot);
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private IEnumerator Kick()
    {
        Debug.Log("trapped");
        yield return null;
    }
}