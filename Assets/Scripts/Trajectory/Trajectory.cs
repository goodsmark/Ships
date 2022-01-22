using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
public class Trajectory : MonoBehaviour
{
    
    LineRenderer _lineRenderer;
    Vector3[] points = new Vector3[100];
    private void Awake()
    { 
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void WriteTrajectory(Vector3 origin, Vector3 speed)
    {
        _lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }
        _lineRenderer.SetPositions(points);
    }

    public void ClearTrajectory() {
        _lineRenderer.SetPositions(new Vector3[0]);
    }
}
