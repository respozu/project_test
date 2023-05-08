using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QualityChanger : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown anisoFiltrationDd;
    [SerializeField] private TMP_Dropdown displayModeDd;
    [SerializeField] private TMP_Dropdown msaaDd;
    [SerializeField] private TMP_Dropdown resolutionDd;
    [SerializeField] private TMP_Dropdown shadowResolutionDd;
    [SerializeField] private Toggle vSyncDd;

    private void Start()
    {
        if(!PlayerPrefs.HasKey(QualityOptions.AnisoFilterKey)) return;
        anisoFiltrationDd.value = PlayerPrefs.GetInt(QualityOptions.AnisoFilterKey);
        displayModeDd.value = PlayerPrefs.GetInt(QualityOptions.DisplayModeKey);
        msaaDd.value = PlayerPrefs.GetInt((QualityOptions.MSAAKey));
        shadowResolutionDd.value = PlayerPrefs.GetInt((QualityOptions.ShadowResKey));
        vSyncDd.isOn = Convert.ToBoolean(PlayerPrefs.GetInt((QualityOptions.VSyncKey)));

        resolutionDd.value = PlayerPrefs.GetInt((QualityOptions.ResolutionHeightKey));
        var resOption = resolutionDd.options;

        for (int i = 0; i < resOption.Count; i++)
        {
            var res = resOption[i].text.Split("x");
            int width = int.Parse(res[0]);
            int height = int.Parse(res[1]);

            if (width == PlayerPrefs.GetInt(QualityOptions.ResolutionWidthKey)
                && height == PlayerPrefs.GetInt(QualityOptions.ResolutionHeightKey))
            {
                resolutionDd.value = i;
            }
        }
    }

    public static void SetAnisotropicFiltration(int value)
    {
        switch (value)
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
        QualityOptionsSaver.Save();
    }

    public static void SetDisplayMode(int value)
    {
        switch (value)
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
            default:
                break;
        }
        QualityOptionsSaver.Save();
    }

    public static void SetMSAA(int value)
    {
        switch (value)
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
            default:
                break;
        }
        QualityOptionsSaver.Save();
    }

    public static void SetResolution(int value)
    {
        switch (value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                break;
            case 1:
                Screen.SetResolution(1680, 1050, Screen.fullScreenMode);
                break;
            case 2:
                Screen.SetResolution(1600, 900, Screen.fullScreenMode);
                break;
            case 3:
                Screen.SetResolution(1280, 720, Screen.fullScreenMode);
                break;
            case 4: 
                Screen.SetResolution(800, 600, Screen.fullScreenMode);
                break;
        }
        QualityOptionsSaver.Save();
    }

    public static void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreenMode);
        QualityOptionsSaver.Save();
    }
    

    public static void SetShadowResolution(int value)
    {
        switch (value)
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
            default:
                break;
        }
        QualityOptionsSaver.Save();
    }

    public static void SetVSync(bool value)
    {
        switch (value)
        {
            case false:
                QualitySettings.vSyncCount = 0;
                break;
            case true:
                QualitySettings.vSyncCount = 1;
                break;
            default:
                break;
        }
        QualityOptionsSaver.Save();
    }
    
    public static void SetVSync(int value)
    {
        switch (value)
        {
            case 0:
                QualitySettings.vSyncCount = 0;
                break;
            case 1:
                QualitySettings.vSyncCount = 1;
                break;
            default:
                break;
        }
        QualityOptionsSaver.Save();
    }
}
