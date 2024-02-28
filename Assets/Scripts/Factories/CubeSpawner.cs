using System.Collections;
using Components;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class CubeSpawner : MonoBehaviour
    {
        public bool readyToSpawn;
        public CubeComponent CubeComponent { get; private set; }
        
        [SerializeField] private Vector3 startPos;
        [SerializeField] private float delay = 0.3f;
        
        private CubeFactory _cubeFactory;
        private Coroutine _coroutine;
        
        [Inject]
        private void Construct(CubeFactory cubeFactory)
        {
            _cubeFactory = cubeFactory;
        }

        private void Start()
        {
            Spawn();
            _coroutine = StartCoroutine("SpawnCubeWithDelay");
        }

        public void Spawn()
        {
            CubeComponent = _cubeFactory.SpawnCube(startPos);
        }

        IEnumerator SpawnCubeWithDelay()
        {
            while (true)
            {
                while (readyToSpawn == false)
                {
                    yield return null;
                }
                
                yield return new WaitForSeconds(delay);
                Spawn();
                readyToSpawn = false;
            }
        }
    }
}