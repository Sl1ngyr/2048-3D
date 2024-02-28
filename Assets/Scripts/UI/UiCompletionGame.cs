using Handlers;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UiCompletionGame : MonoBehaviour
    {
        [SerializeField] private int _finalCompletionValue = 4096;
        [SerializeField] private GameObject _components;
        [SerializeField] private TextMeshProUGUI _textOnScreen;
        [SerializeField] private string _scoreText = "Your score: ";
        
        private UiPointsCalculate _uiPointsCalculate;
        private MotionHandler _motionHandler;
        
        [Inject]
        private void Construct(UiPointsCalculate uiPointsCalculate, MotionHandler motionHandler)
        {
            _uiPointsCalculate = uiPointsCalculate;
            _motionHandler = motionHandler;
        }
        
        public void CheckFinalPoints(int points)
        {
            if (points == _finalCompletionValue)
            {
                StartCompletingGame();
            }
        }

        private void StartCompletingGame()
        {
            Time.timeScale = 0;
            _components.SetActive(true);
            _textOnScreen.text = _scoreText + _uiPointsCalculate.TotalScoreOnScreen;
            _motionHandler.gameObject.SetActive(false);
        }
    }
}