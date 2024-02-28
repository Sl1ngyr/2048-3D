using Factories;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Handlers
{
    public class MotionHandler : MonoBehaviour, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Camera _camera;

        private CubeSpawner _cubeSpawner;

        [Inject]
        private void Construct(CubeSpawner cubeSpawner)
        {
            _cubeSpawner = cubeSpawner;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _cubeSpawner.readyToSpawn = true;
            _cubeSpawner.CubeComponent.LaunchCube();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_cubeSpawner.CubeComponent != null && _cubeSpawner.readyToSpawn == false)
            {
                var cubeComponent = _cubeSpawner.CubeComponent;
                var curScreenPoint = new Vector3(Input.mousePosition.x, cubeComponent.transform.position.y,
                    cubeComponent.transform.position.z);

                Vector3 curPosition = _camera.ScreenToWorldPoint(curScreenPoint);
                cubeComponent.transform.position = new Vector3(-curPosition.x, cubeComponent.transform.position.y,
                    cubeComponent.transform.position.z);
            }
        }
    }
}