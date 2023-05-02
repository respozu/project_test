using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform attachedTransform;
    [SerializeField] private Vector2 cameraYPositionBorder;
    [SerializeField] private Vector2 cameraZPositionBorder;

    [SerializeField] private float speed;

    private void Update()
    {
        Vector3 newPosition = new Vector3
            (transform.position.x, 
            Mathf.Clamp(attachedTransform.position.y, cameraYPositionBorder.x, cameraYPositionBorder.y),
            Mathf.Clamp(attachedTransform.position.z, cameraZPositionBorder.x, cameraZPositionBorder.y));
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}
