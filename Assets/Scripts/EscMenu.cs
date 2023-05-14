using System;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        InputManager.SceneInput.UI.ESCPress.performed += context => TogglePanelActiveness();
    }
    
    private void TogglePanelActiveness()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf)
        {
            InputManager.SceneInput.Player.Disable();
            Cursor.visible = true;
        }
        else
        {
            InputManager.SceneInput.Player.Enable();
            Cursor.visible = false;
        }
    }
}