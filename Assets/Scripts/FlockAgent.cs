using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public Collider2D AgentCollider { get; private set; }
    public Flock AgentFlock { get; private set; }

    private void Start()
    {
        AgentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock) => AgentFlock = flock;

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
    
    
}
