using System.Collections.Generic;
using System.Linq;
using Filter_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Behaviour_Scripts
{
    [System.Serializable]
    public class SetBehaviour
    {
        [FormerlySerializedAs("Behaviour")] 
        public FlockBehaviour behaviour;
        public ContextFilter contextFilter;
        [FormerlySerializedAs("Weight")] 
        public float weight;
        
    }
    
    
    [CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
    public class CompositeBehaviour : FlockBehaviour
    {
        [SerializeField] private SetBehaviour[] behaviours;
        
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 move = Vector2.zero;

            foreach (var behaviour in behaviours)
            {
                var filterContext = behaviour.contextFilter != null
                    ? behaviour.contextFilter.Filter(agent, context)
                    : context;

                Vector2 partialMove = behaviour.behaviour.CalculateMove(agent, filterContext, flock) * behaviour.weight;

                if (partialMove.magnitude == 0) continue;
                
                if (partialMove.sqrMagnitude > behaviour.weight * behaviour.weight)
                {
                    partialMove.Normalize();
                    partialMove *= behaviour.weight;
                }

                move += partialMove;
            }

            return move;
        }
    }
}