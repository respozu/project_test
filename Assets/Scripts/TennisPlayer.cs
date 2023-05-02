using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisPlayer : MonoBehaviour
{
    [SerializeField] private GameObject directionPoint;

    [SerializeField] private float rotationSpeed;

    private bool _isKicked;

    private PlayerInput _input;

    private float _startXPos;
    private float _startZRot;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Click.performed += context => StartKickCoroutine();

        _startXPos = transform.position.x;
        _startZRot = transform.eulerAngles.z;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Update()
    {
        TransformRacket();

        
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void TransformRacket()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        Vector3 newPositionWithoutX = new Vector3(transform.position.x, newPosition.y, newPosition.z);

        transform.position = newPositionWithoutX;

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newPosition.z * rotationSpeed + _startZRot);
    }



    private void StartKickCoroutine()
    {
        _isKicked = true;
        StartCoroutine(Kick());
    }

    private IEnumerator Kick()
    {
        Vector3 pos = transform.position;
        float goingX = pos.x - 1;
        while (_isKicked)
        {
            pos.x = Mathf.Lerp(pos.x, goingX, 0.2f);
            transform.position = pos;
            if (Mathf.Abs(transform.position.x - goingX) <= 0.1f) _isKicked = false; 
            yield return new WaitForFixedUpdate();
        }
        bool kickEnds = true;
        float returningX = goingX + 1;
        while (kickEnds)
        {
            pos.x = Mathf.Lerp(pos.x, returningX, 0.2f);
            transform.position = pos;
            if (Mathf.Abs(transform.position.x - returningX) <= 0.1f) kickEnds = false;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}