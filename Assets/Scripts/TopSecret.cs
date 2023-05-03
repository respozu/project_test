using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class TopSecret : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private float textSpeed;
    [SerializeField] private float textPauseInterval;

    private float _defaultAlpha;
    private float _triggeredAlpha = 1;

    private bool _canReset = true;

    private void Start()
    {
        _defaultAlpha = _text.alpha;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_canReset) StartCoroutine(ResetAlpha());   
    }

    private IEnumerator ResetAlpha()
    {
        _canReset = false;
        float newAlpha;
        bool increaseAlpha = true;

        while (_text.color.a < 1 && increaseAlpha)
        {
            Color newColor = _text.color;

            newAlpha = Mathf.MoveTowards(_text.alpha, _triggeredAlpha, Time.deltaTime * textSpeed);
            newColor.a = newAlpha;

            _text.color = newColor;

            yield return null;
        }
        yield return new WaitForSeconds(textPauseInterval);
        while (_text.color.a > 0)
        {
            Color newColor = _text.color;

            newAlpha = Mathf.MoveTowards(_text.alpha, _defaultAlpha, Time.deltaTime * textSpeed);
            newColor.a = newAlpha;

            _text.color = newColor;

            yield return null;
        }
        _canReset = true;
        yield break;
    }
}
