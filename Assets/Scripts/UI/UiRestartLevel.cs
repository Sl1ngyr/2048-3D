using Handlers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UiRestartLevel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private int _valueScene = 0;
        
        private MotionHandler _motionHandler;
        
        [Inject]
        private void Construct(MotionHandler motionHandler)
        {
            _motionHandler = motionHandler;
        }
        
        private void Start()
        {
            _restartButton.onClick.AddListener(RestartLevelWithButton);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(RestartLevelWithButton);
        }

        private void RestartLevelWithButton()
        {
            Time.timeScale = 1;
            
            _motionHandler.gameObject.SetActive(true);
            
            SceneManager.LoadScene(_valueScene);
        }
    }
}