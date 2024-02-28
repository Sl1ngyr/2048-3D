using Components;
using UnityEngine;

namespace Factories
{
    public class CubeFactory
    {
        private readonly CubeComponent.Factory _factory;

        public CubeFactory(CubeComponent.Factory factory)
        {
            _factory = factory;
        }

        public CubeComponent SpawnCube(Vector3 spawnPos)
        {
            var cube = _factory.Create();
            cube.transform.position = spawnPos;
            return cube;
        }
        
    }
}