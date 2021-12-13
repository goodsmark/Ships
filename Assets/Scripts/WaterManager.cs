using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] verticles = meshFilter.mesh.vertices;
        for (int i = 0; i < verticles.Length; i++)
        {
            verticles[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + verticles[i].x);
        }
        meshFilter.mesh.vertices = verticles;

        meshFilter.mesh.RecalculateNormals();
    }
}
