using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QualityOptions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown _anisoFilterDropdown;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private TMP_Dropdown msaaDropdown;
    [SerializeField] private TMP_Dropdown shadowsResolutionDropdown;

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

    public void SetMSAA(int index)
    {
        switch(index)
        {
            case 0:
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                QualitySettings.antiAliasing = 2;
                break;
            case 2:
                QualitySettings.antiAliasing = 4;
                    break;
            case 3:
                QualitySettings.antiAliasing = 8;
                break;


        }
    }

    public void SetShadowResolution(int index)
    {
        switch(index)
        {
            case 0:
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
            case 2:
                QualitySettings.shadowResolution = ShadowResolution.High;
                break;
            case 3:
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                break;
            
        }
    }
}