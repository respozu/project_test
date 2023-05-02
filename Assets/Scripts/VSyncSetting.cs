using UnityEngine;
using UnityEngine.UI;

public class VSyncSetting : MonoBehaviour
{
    [SerializeField] private Toggle vSyncToggle;

    public void SetVSync(bool newvalue)
    {
        QualitySettings.vSyncCount = (newvalue ? 1 : 0);
    }
}
