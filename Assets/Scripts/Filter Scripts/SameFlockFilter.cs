using System.Collections.Generic;
using UnityEngine;

namespace Filter_Scripts.Filter_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
    public class SameFlockFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> originalNeighbors)
        {
            List<Transform> filtered = new List<Transform>();

            foreach (var neighbor in originalNeighbors)
            {
                var neighborAgent = neighbor.GetComponent<FlockAgent>();

                if (!neighborAgent || neighborAgent.AgentFlock != agent.AgentFlock) continue;
                
                filtered.Add(neighbor);
            }

            return filtered;
        }
    }
}