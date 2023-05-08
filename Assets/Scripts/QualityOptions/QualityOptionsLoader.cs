using UnityEngine;

public class QualityOptionsLoader : MonoBehaviour
{
    public static void Load()
    {
        if (!PlayerPrefs.HasKey(QualityOptions.AnisoFilterKey))
        {
            Debug.LogError("Trying to load settings from PlayerPrefs, but keys not exist.");
            return;
        }

        QualityChanger.SetAnisotropicFiltration(PlayerPrefs.GetInt(QualityOptions.AnisoFilterKey));
        QualityChanger.SetDisplayMode(PlayerPrefs.GetInt(QualityOptions.DisplayModeKey));
        QualityChanger.SetMSAA(PlayerPrefs.GetInt(QualityOptions.MSAAKey));
        QualityChanger.SetResolution(PlayerPrefs.GetInt(QualityOptions.ResolutionWidthKey), PlayerPrefs.GetInt(QualityOptions.ResolutionHeightKey));
        QualityChanger.SetShadowResolution(PlayerPrefs.GetInt(QualityOptions.ShadowResKey));
        QualityChanger.SetVSync(PlayerPrefs.GetInt(QualityOptions.VSyncKey));
    }
}
