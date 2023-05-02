using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisPlayer : MonoBehaviour
{
    [SerializeField] private GameObject directionPoint;

    [SerializeField] private float rotationSpeed;

    private float _startXRot;
    private float _startYRot;
    private float _startZRot;

    private void Awake()
    {
        _startXRot = transform.eulerAngles.x;
        _startYRot = transform.eulerAngles.y;
        _startZRot = transform.eulerAngles.z;
        Debug.Log($"{_startXRot} {_startYRot} {_startZRot}");
    }

    private void Update()
    {
        Vector3 racketNewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 1));
        transform.position = racketNewPosition;
        transform.rotation = Quaternion.Euler(_startXRot, _startYRot, racketNewPosition.z * rotationSpeed + _startZRot);
        //Debug.Log(racketNewPosition);
    }
}