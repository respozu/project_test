using UnityEngine;
using UnityEngine.UI;

public class AnisoFilterSetting : MonoBehaviour
{
    [SerializeField] private Dropdown _anisoFilterDropdown;

    public void SetAnisoFilter(int index)
    {
        switch(index)
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
}
