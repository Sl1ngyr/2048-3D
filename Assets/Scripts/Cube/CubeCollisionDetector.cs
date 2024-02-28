using System;
using UnityEngine;

namespace Cube
{
    public class CubeCollisionDetector : MonoBehaviour
    {
        public event Action<PointsContainer> onCollisionDetect;

        
        
        private void OnCollisionEnter(Collision col)
        {
            var colContainer = col.gameObject.GetComponent<PointsContainer>();
            if (colContainer == null)
                return;
            
            onCollisionDetect?.Invoke(colContainer);
            
        }
    }
}