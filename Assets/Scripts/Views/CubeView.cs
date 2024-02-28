using System.Collections.Generic;
using Cube;
using TMPro;
using UnityEngine;

namespace Views
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private TextMeshPro[] _texts;
        [SerializeField] private List<MaterialSettings> _settings = new List<MaterialSettings>();

        private PointsContainer _container;

        private void Awake()
        {
            _container = GetComponent<PointsContainer>();
            SetPoints(_container.Points);
        }

        private void SetPoints(int points)
        {
            foreach (var text in _texts)
            {
                text.text = points.ToString();
            }

            var settings = _settings.Find(texture => texture.points == points);

            if (settings == null)
                _renderer.material = default;
            else
                _renderer.material = settings.material;
        }


        private void OnEnable()
        {
            _container.onPointsChanged += SetPoints;
        }

        private void OnDisable()
        {
            _container.onPointsChanged -= SetPoints;
        }
    }

    [System.Serializable]
    public class MaterialSettings
    {
        public int points;
        public Material material;
    }
}