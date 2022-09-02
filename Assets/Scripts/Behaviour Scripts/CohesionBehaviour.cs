using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Behaviour_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
    public class CohesionBehaviour : FlockBehaviour
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return Vector2.zero;
            
            Vector2 cohesionMove = Vector2.zero;

            foreach (var contextAgentTransform in context) 
                cohesionMove += (Vector2)contextAgentTransform.position;
            cohesionMove /= context.Count;

            cohesionMove -= (Vector2)agent.transform.position;

            return cohesionMove;
        }
    }
}