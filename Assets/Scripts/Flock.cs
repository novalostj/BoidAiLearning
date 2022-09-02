using System;
using System.Collections.Generic;
using Filter_Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flock : MonoBehaviour
{
    [SerializeField] private FlockAgent agentPrefab;
    [SerializeField] private FlockBehaviour behaviour;

    [Range(10, 500)] public int startingCount = 250;
    [Range(1, 100f)] public float driveFactor = 10f;
    [Range(1, 100f)] public float maxSpeed = 5f;
    private const float AgentDensity = 0.08f;

    [Range(1, 10)] public float neighborRadius = 1.5f;
    [Range(0, 1)] public float avoidanceMultiplierRadius = 0.5f;

    private List<FlockAgent> agents = new();
    
    private float SquareMaxSpeed => maxSpeed * maxSpeed;
    private float SquareNeighborRadius => neighborRadius * neighborRadius;
    public float SquareAvoidanceRadius => SquareNeighborRadius * avoidanceMultiplierRadius * avoidanceMultiplierRadius;


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, startingCount * AgentDensity);
    }

    private void Start()
    {
        ResetFlock();
    }
        
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ResetFlock();

        AnimatedFlock();
    }

    private void AnimatedFlock()
    {
        foreach (var agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            Vector2 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;

            if (move.sqrMagnitude > SquareMaxSpeed) move = move.normalized * maxSpeed;
                
            agent.Move(move);
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new();
        var contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        foreach (var col2D in contextColliders)
        {
            if (col2D.transform != agent.transform) context.Add(col2D.transform);
        }

        return context;
    }
        
    private void CreateFlock()
    {
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle * (startingCount * AgentDensity),
                Quaternion.Euler(Vector3.forward * Random.Range(0, 360f)), transform);

            newAgent.name = $"Agent {i}";
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    private void RemoveFlock()
    {
        foreach (var agent in agents) Destroy(agent.gameObject);
        agents = new List<FlockAgent>();
    }

    private void ResetFlock()
    {
        RemoveFlock();
        CreateFlock();
    }
}