using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

    public float waveHeight = 7f, waveFrenquency = 1f, waveSpeed = 1f;

    public Transform ocean;

    public static OceanManager instance;


    Material oceanMat;
    Texture2D displacementWater;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance alredy exists");
            Destroy(this);
        }
        SetVariables();
    }


    void SetVariables()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        displacementWater = (Texture2D)oceanMat.GetTexture("_WaveDisplacement");
    }

    public float WaterHeightAtPositions( Vector3 position)
    {
        return ocean.position.y + displacementWater.GetPixelBilinear(position.x * waveFrenquency / 100, position.z * waveFrenquency / 100 + Time.time * waveSpeed / 100).g * waveHeight / 10 * ocean.localScale.x;
    }

    private void OnValidate()
    {
        if (!oceanMat)
        {
            SetVariables();
        }
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        oceanMat.SetFloat("_WavesSpeed", waveSpeed / 100);
        oceanMat.SetFloat("_WavesFrenquency", waveFrenquency / 100);
        oceanMat.SetFloat("_WavesHeights", waveHeight / 10);
    }
}

