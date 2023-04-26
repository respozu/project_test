using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : MonoBehaviour
{
    private Transform _barrel;

    private void Start()
    {
        _barrel = transform.GetChild(0).GetComponent<Transform>();
    }
}