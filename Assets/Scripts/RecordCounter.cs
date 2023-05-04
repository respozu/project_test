using TMPro;
using UnityEngine;

public class RecordCounter : MonoBehaviour
{
    private int _score;
    public int Score => _score;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TennisBall"))
        {
            _score++;
        }
    }

    public void ResetScore()
    {
        _score = 0;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score}";
    }
}

