using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static PlayerInput SceneInput;

    private void Awake()
    {
        SceneInput = new PlayerInput();
    }

    private void OnEnable()
    {
        SceneInput.Enable();
    }

    private void OnDisable()
    {
        SceneInput.Disable();
    }
}