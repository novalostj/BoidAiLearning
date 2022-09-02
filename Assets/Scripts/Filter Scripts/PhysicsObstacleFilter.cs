using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Filter_Scripts.Filter_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Filter/Physics Obstacle")]
    public class PhysicsObstacleFilter : ContextFilter
    {
        [SerializeField] private LayerMask layerMask;
        
        public override List<Transform> Filter(FlockAgent agent, List<Transform> originalNeighbors)
        {
            List<Transform> filtered = new List<Transform>();

            foreach (var neighbor in originalNeighbors)
                if (layerMask == (layerMask | (1 << neighbor.gameObject.layer)))
                    filtered.Add(neighbor);
            
            return filtered;
        }
    }
}