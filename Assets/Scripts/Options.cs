using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Dropdown _anisoFilterDropdown;
    [SerializeField] private Toggle vSyncToggle;

    public void SetResolution()
    {
        int selectedIndex = resolutionDropdown.value;

        string resolutionString = resolutionDropdown.options[selectedIndex].text;

        string[] resolutionValue = resolutionString.Split('x');
        int width = int.Parse(resolutionValue[0]);
        int height = int.Parse(resolutionValue[1]);

        Screen.SetResolution(width, height, Screen.fullScreen);
    }


    public void SetAnisoFilter(int index)
    {
        switch (index)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                break;
            default:
                break;
        }

    }


    public void SetVSync(bool newvalue)
    {
        QualitySettings.vSyncCount = (newvalue ? 1 : 0);
    }
}