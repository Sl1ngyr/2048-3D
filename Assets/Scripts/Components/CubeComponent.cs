using UnityEngine;
using Zenject;

namespace Components
{
    public class CubeComponent : MonoBehaviour
    {
        [SerializeField] private int _launchForce = 15;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void LaunchCube()
        {
            _rigidbody.AddForce(transform.forward * _launchForce, ForceMode.Impulse);
        }

        public class Factory : PlaceholderFactory<CubeComponent>
        {

        }
    }
}
