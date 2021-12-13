using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

    public float waveHeight = 0.5f, waveFrenquency = 1f, waveSpeed = 1f;

    public Transform ocean;

    Material oceanMat;
    Texture2D displacementWater;

    void Start()
    {
        
    }

    void SetVariables()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        displacementWater = (Texture2D)oceanMat.GetTexture("");
    }

    public float WaterHeightAtPositions( Vector3 position)
    {
        return ocean.position.y + displacementWater.GetPixelBilinear(position.x * waveFrenquency, position.z * waveFrenquency + Time.time * waveSpeed).g * waveHeight * ocean.localScale.x;
    }
    private void OnValidate()
    {
        if (!oceanMat)
        {
            SetVariables();
            UpdateMaterial();
        }
    }

    private void UpdateMaterial()
    {
        oceanMat.SetFloat("_RefractionSpeed", waveSpeed);
        oceanMat.SetFloat("_RefractionStrenght", waveFrenquency);
        oceanMat.SetFloat("", waveHeight);
    }
}

