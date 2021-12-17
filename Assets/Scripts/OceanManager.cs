using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

<<<<<<< HEAD
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
=======
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
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    }

    public float WaterHeightAtPositions( Vector3 position)
    {
<<<<<<< HEAD
        return ocean.position.y + displacementWater.GetPixelBilinear(position.x * waveFrenquency / 100, position.z * waveFrenquency / 100 + Time.time * waveSpeed / 100).g * waveHeight / 10 * ocean.localScale.x;
    }

=======
        return ocean.position.y + displacementWater.GetPixelBilinear(position.x * waveFrenquency, position.z * waveFrenquency + Time.time * waveSpeed).g * waveHeight * ocean.localScale.x;
    }
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    private void OnValidate()
    {
        if (!oceanMat)
        {
            SetVariables();
<<<<<<< HEAD
        }
        UpdateMaterial();
=======
            UpdateMaterial();
        }
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    }

    private void UpdateMaterial()
    {
<<<<<<< HEAD
        oceanMat.SetFloat("_WavesSpeed", waveSpeed / 100);
        oceanMat.SetFloat("_WavesFrenquency", waveFrenquency / 100);
        oceanMat.SetFloat("_WavesHeights", waveHeight / 10);
=======
        oceanMat.SetFloat("_RefractionSpeed", waveSpeed);
        oceanMat.SetFloat("_RefractionStrenght", waveFrenquency);
        oceanMat.SetFloat("", waveHeight);
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    }
}

