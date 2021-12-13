using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer lineRenderer;
    Vector3[] points = new Vector3[100];
    private void Start()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void WriteTrajectory(Vector3 origin, Vector3 speed)
    {
        lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }
        lineRenderer.SetPositions(points);
    }
}
