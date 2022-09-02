using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
    public class AlignmentBehaviour : FlockBehaviour
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return agent.transform.up;
            
            Vector2 alignmentMove = Vector2.zero;

            foreach (var contextAgentTransform in context) 
                alignmentMove += (Vector2)contextAgentTransform.up;
            
            alignmentMove /= context.Count;
            
            return alignmentMove;
        }
    }
}