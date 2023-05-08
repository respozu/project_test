using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TennisRacket : MonoBehaviour
{
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 newPos, Quaternion newRot)
    {
        _rb.Move(newPos, newRot);
    }
}
