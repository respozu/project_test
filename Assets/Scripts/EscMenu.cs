using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        InputManager.SceneInput.UI.ESCPress.performed += context => TogglePanelActivness();
    }

    private void TogglePanelActivness()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf) InputManager.SceneInput.Player.Disable();
        else InputManager.SceneInput.Player.Enable();
    }
}