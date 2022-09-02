using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
    public class SteeredCohesionBehaviour : FlockBehaviour
    {
        private Vector2 currentVelocity;
        [SerializeField] private float agentSmoothTime = 0.5f;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return Vector2.zero;
            
            Vector2 cohesionMove = Vector2.zero;

            foreach (var contextAgentTransform in context) 
                cohesionMove += (Vector2)contextAgentTransform.position;
            cohesionMove /= context.Count;

            cohesionMove -= (Vector2)agent.transform.position;
            cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);

            return cohesionMove;
        }
    }
}