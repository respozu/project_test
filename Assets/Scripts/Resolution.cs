using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;

    public void SetResolution()
    {
        int selectedIndex = resolutionDropdown.value;

        string resolutionString = resolutionDropdown.options[selectedIndex].text;

        string[] resolutionValue = resolutionString.Split('x');
        int width = int.Parse(resolutionValue[0]);
        int height = int.Parse(resolutionValue[1]);

        Screen.SetResolution(width, height, Screen.fullScreen);
    }

}
