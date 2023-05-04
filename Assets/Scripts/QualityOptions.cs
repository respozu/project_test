using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QualityOptions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown _anisoFilterDropdown;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private TMP_Dropdown msaaDropdown;
    [SerializeField] private TMP_Dropdown shadowsResolutionDropdown;
    [SerializeField] private TMP_Dropdown displayModeDropdown;

    private string resolutionKey = "resolution";
    private string anisoFilterKey = "anisoFilter";
    private string vSyncKey = "vSync";
    private string msaaKey = "msaa";
    private string shadowResKey = "shadowResolution";
    private string displayModeKey = "displayMode";

    private void Start()
    {
        LoadOptions();
    }

    public void SetResolution()
    {
        int selectedIndex = resolutionDropdown.value;

        string resolutionString = resolutionDropdown.options[selectedIndex].text;

        string[] resolutionValue = resolutionString.Split('x');
        int width = int.Parse(resolutionValue[0]);
        int height = int.Parse(resolutionValue[1]);

        Screen.SetResolution(width, height, Screen.fullScreen);

        PlayerPrefs.SetInt(resolutionKey, selectedIndex);
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

        PlayerPrefs.SetInt(anisoFilterKey, index);
    }


    public void SetVSync(bool newvalue)
    {
        QualitySettings.vSyncCount = (newvalue ? 1 : 0);

        PlayerPrefs.SetInt(vSyncKey, (newvalue ? 1 : 0));
    }

    public void SetMSAA(int index)
    {
        switch (index)
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

        PlayerPrefs.SetInt(msaaKey, index);
    }

    public void SetShadowResolution(int index)
    {
        switch (index)
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

        PlayerPrefs.SetInt(shadowResKey, index);
    }

    public void SetDisplayMode(int index)
    {
        switch (index)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
        }

        PlayerPrefs.SetInt(displayModeKey, index);
    }

    private void LoadOptions()
    {
        int resolutionIndex = PlayerPrefs.GetInt(resolutionKey, 0);
        int anisoFilterIndex = PlayerPrefs.GetInt(anisoFilterKey, 1);
        bool vSync = PlayerPrefs.GetInt(vSyncKey, 1) == 1 ? true : false;
        int msaaIndex = PlayerPrefs.GetInt(msaaKey, 1);
        int shadowResIndex = PlayerPrefs.GetInt(shadowResKey, 2);
        int displayModeIndex = PlayerPrefs.GetInt(displayModeKey, 0);

    }
}
