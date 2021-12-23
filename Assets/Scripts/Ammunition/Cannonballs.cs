using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonballs : AmmunitionMain, IAmmunitionMain
{
    public int damage;
    public float roundSpeed;

    [SerializeField]GameObject cannonbal;
    AmmunitionMain ammunitionMain;
    Izanami izanami;

    void Start() {

        ammunitionMain = FindObjectOfType<AmmunitionMain>();
        izanami = FindObjectOfType<Izanami>();
    }

    public void Fire()
    {
       ammunitionMain.Fire(cannonbal, roundSpeed, izanami.leftGuns);
    }
}
