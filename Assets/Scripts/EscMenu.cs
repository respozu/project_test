using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.UI.ESCPress.performed += context => TogglePanelActivness();
    }

    private void TogglePanelActivness()
    {
        panel.SetActive(!panel.activeSelf);
    }

}