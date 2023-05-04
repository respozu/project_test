using TMPro;
using UnityEngine;

public class RecordCounter : MonoBehaviour
{
    private int _score;
    public int Score => _score;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TennisBall"))
        {
            _score++;
            UpdateScoreText();
        }
    }

    public void ResetScore()
    {
        _score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {_score}";
    }
}

