using TMPro;
using UnityEngine;

namespace UI
{
    public class UiPointsCalculate : MonoBehaviour
    {
        private const float DIVISION_VALUE = 2;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _scoreText = "Scores: ";

        public int TotalScoreOnScreen { get; private set; }

        private void Start()
        {
            TotalScoreOnScreen = 0;
        }

        public void CalculatePoints(int points)
        {
            TotalScoreOnScreen += (int)(points / DIVISION_VALUE);
            
            _text.text = _scoreText + TotalScoreOnScreen;
        }
    }
}