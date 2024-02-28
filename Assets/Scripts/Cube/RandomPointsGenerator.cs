using UnityEngine;

namespace Cube
{
    public class RandomPointsGenerator : MonoBehaviour
    {
        private const int CHANCE_PROBABILITY = 75;
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private const int INITIAL_VALUE_OF_CUBE = 2;
        private const int DEGREE = 2;
        
        private PointsContainer _pointsContainer;
        
        private void Start()
        {
            _pointsContainer = GetComponent<PointsContainer>();
            _pointsContainer.Points = RandomValueOfInitialCube();
        }

        private int RandomValueOfInitialCube()
        {
            var value = Random.Range(MIN_VALUE, MAX_VALUE);

            if (value <= CHANCE_PROBABILITY)
            {
                return INITIAL_VALUE_OF_CUBE;
            }
            else
            {
                return (int)Mathf.Pow(INITIAL_VALUE_OF_CUBE, DEGREE);
            }
        }
    }
}