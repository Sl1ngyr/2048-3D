using UI;
using UnityEngine;
using Zenject;

namespace Cube
{
    public class CubeCollisionMerge : MonoBehaviour
    {
        private const int STATIC_DEGREE = 2;

        [SerializeField] private int _touchForce = 5;

        private PointsContainer _pointsContainer;
        private Rigidbody _rigidbody;
        private CubeCollisionDetector _detector;

        private UiPointsCalculate _uiPointsCalculate;
        
        [Inject]
        private void Construct(UiPointsCalculate uiPointsCalculate)
        {
            _uiPointsCalculate = uiPointsCalculate;
        }
        
        private void Awake()
        {
            _pointsContainer = GetComponent<PointsContainer>();
            _rigidbody = GetComponent<Rigidbody>();
            _detector = GetComponent<CubeCollisionDetector>();
        }


        private void MergeCube(PointsContainer col)
        {
            if (_pointsContainer.Points == col.Points)
            {
                OnTouchCube();
                _pointsContainer.Points *= STATIC_DEGREE;
                Destroy(col.gameObject);
                _uiPointsCalculate.CalculatePoints(col.Points);
            }
        }

        private void OnTouchCube()
        {
            _rigidbody.AddForce(transform.up * _touchForce, ForceMode.Impulse);
        }
        
        private void OnEnable()
        {
            _detector.onCollisionDetect += MergeCube;
        }

        private void OnDisable()
        {
            _detector.onCollisionDetect -= MergeCube;
        }
    }
}