using System.Collections.Generic;
using UnityEngine;

namespace Filter_Scripts
{
    public abstract class ContextFilter : ScriptableObject
    {
        public abstract List<Transform> Filter(FlockAgent agent, List<Transform> originalNeighbors);
    }
}