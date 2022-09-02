using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Behaviour_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
    public class AvoidanceBehaviour : FlockBehaviour
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return Vector2.zero;
            
            Vector2 avoidanceMove = Vector2.zero;

            int nAvoid = 0;
            foreach (var contextAgentTransform in context)
            {
                if (!(Vector2.SqrMagnitude(contextAgentTransform.position - agent.transform.position) <
                      flock.SquareAvoidanceRadius)) continue;
                
                avoidanceMove += (Vector2)(agent.transform.position - contextAgentTransform.position);
                nAvoid++;
            }

            if (nAvoid > 0) avoidanceMove /= nAvoid;

            return avoidanceMove;
        }
    }
}