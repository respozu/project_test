using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    private TextMeshProUGUI _fpsText;

    private void Start()
    {
        _fpsText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(UpdateFPS());
    }

    private System.Collections.IEnumerator UpdateFPS()
    {
        while (true)
        {
            float fps = 1f / Time.unscaledDeltaTime;
            _fpsText.text = "FPS: " + Mathf.RoundToInt(fps);
            _fpsText.text += "\nFixedFPS: " + Mathf.RoundToInt(1f / Time.fixedDeltaTime);

            yield return new WaitForSeconds(0.5f);
        }
    }
}