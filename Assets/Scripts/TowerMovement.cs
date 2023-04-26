using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;

    private void Update()
    {
       if (Input.GetKey(KeyCode.Keypad4))
        {
            Quaternion rotation = Quaternion.Euler(0f, -_rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = transform.rotation * rotation;

      
        }
       if (Input.GetKey(KeyCode.Keypad5))
        {
            Quaternion rotation = Quaternion.Euler(0f, _rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = transform.rotation * rotation;
        }
    } 

}
