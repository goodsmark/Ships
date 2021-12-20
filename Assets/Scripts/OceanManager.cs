using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

    public float waveHeight = 7f, waveFrenquency = 1f, waveSpeed = 1f;

    public Transform ocean;

    public static OceanManager instance;


    Material _oceanMat;
    Texture2D _displacementWater;

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
        _oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        _displacementWater = (Texture2D)_oceanMat.GetTexture("_WaveDisplacement");
    }

    public float WaterHeightAtPositions( Vector3 position)
    {
        return ocean.position.y + _displacementWater.GetPixelBilinear(position.x * waveFrenquency / 100, position.z * waveFrenquency / 100 + Time.time * waveSpeed / 100).g * waveHeight / 10 * ocean.localScale.x;
    }

    private void OnValidate()
    {
        if (!_oceanMat)
        {
            SetVariables();
        }
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        _oceanMat.SetFloat("_WavesSpeed", waveSpeed / 100);
        _oceanMat.SetFloat("_WavesFrenquency", waveFrenquency / 100);
        _oceanMat.SetFloat("_WavesHeights", waveHeight);
    }
}

