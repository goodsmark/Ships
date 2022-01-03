using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonballs : AmmunitionMain, IAmmunitionMain
{
    public int damage;
    public float roundSpeed;

    [SerializeField]GameObject cannonbal;
    Izanami izanami;

    void Start() {

        izanami = FindObjectOfType<Izanami>();
    }

    public void Fire(Transform[] gunPosition)
    {
        
       ammunitionMain.Fire(cannonbal, roundSpeed, gunPosition);
    }
    public void Fire(Transform gunPosition)
    {

        ammunitionMain.Fire(cannonbal, roundSpeed, gunPosition);
    }
}
