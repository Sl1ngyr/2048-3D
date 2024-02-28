using System;
using UI;
using UnityEngine;
using Zenject;

namespace Cube
{
    public class PointsContainer : MonoBehaviour
    {
        [SerializeField] private int _points;

        private UiCompletionGame _uiCompletionGame;
        
        [Inject]
        private void Construct(UiCompletionGame uiCompletionGame)
        {
            _uiCompletionGame = uiCompletionGame;
        }
        
        public int Points
        {
            get => _points;
            set
            {
                if (_points == value)
                    return;

                _points = value;
                onPointsChanged?.Invoke(_points);
                _uiCompletionGame.CheckFinalPoints(_points);
            }
        }

        public event Action<int> onPointsChanged;
    }
}