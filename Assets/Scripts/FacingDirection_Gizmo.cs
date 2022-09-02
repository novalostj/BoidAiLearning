using System;
using UnityEngine;

public class FacingDirection_Gizmo : MonoBehaviour
{
    [Range(0, 1)] public float lineLength = 0.2f; 
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up * lineLength);
    }
}
