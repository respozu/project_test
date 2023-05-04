using UnityEngine;

public class GraphicOptionsLoader : MonoBehaviour
{
    void Start()
    {
        LoadOptions();
    }

    public void LoadOptions()
    {
        int resolutionIndex = PlayerPrefs.GetInt(QualityOptions.ResolutionKey);
        int anisoFilterIndex = PlayerPrefs.GetInt(QualityOptions.AnisoFilterKey);
        int msaaIndex = PlayerPrefs.GetInt(QualityOptions.MSAAKey);
        int shadowResIndex = PlayerPrefs.GetInt(QualityOptions.ShadowResKey);
        int displayModeIndex = PlayerPrefs.GetInt(QualityOptions.DisplayModeKey);

        bool vSync = PlayerPrefs.GetInt(QualityOptions.VSyncKey) == 1 ? true : false;
    }
}