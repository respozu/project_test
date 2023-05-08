using UnityEngine;

public class QualityOptionsSaver : MonoBehaviour
{
    public static void Save()
    {
        PlayerPrefs.SetInt(QualityOptions.AnisoFilterKey, (int)QualitySettings.anisotropicFiltering);
        PlayerPrefs.SetInt(QualityOptions.DisplayModeKey, (int)Screen.fullScreenMode);
        PlayerPrefs.SetInt(QualityOptions.MSAAKey, QualitySettings.antiAliasing);
        
        PlayerPrefs.SetInt(QualityOptions.ResolutionWidthKey, Screen.currentResolution.width);
        PlayerPrefs.SetInt(QualityOptions.ResolutionHeightKey, Screen.currentResolution.height);
        
        PlayerPrefs.SetInt(QualityOptions.ShadowResKey, (int)QualitySettings.shadowResolution);
        PlayerPrefs.SetInt(QualityOptions.VSyncKey, QualitySettings.vSyncCount);
        
        PlayerPrefs.Save();
    }
}