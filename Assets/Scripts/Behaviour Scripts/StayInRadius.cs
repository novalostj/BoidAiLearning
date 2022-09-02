using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Behaviour/Stay In Radius")]
    public class StayInRadius : FlockBehaviour
    {
        public Vector2 center = Vector2.zero;
        public float radius = 15f;
        
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 centerOffset = center - (Vector2)agent.transform.position;

            float t = centerOffset.magnitude / radius;

            if (t < 0.9f) return Vector2.zero;

            return centerOffset * (t * t);
        }
    }
}