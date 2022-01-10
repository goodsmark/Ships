using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonballs : ShipAmmunitions                   
{   
    [SerializeField]GameObject cannonbal;

    int damage;
    float roundSpeed;


    public Cannonballs(int damage,float roundSpeed, GameObject cannonbal) : base(damage, roundSpeed) 
    {
        this.roundSpeed = roundSpeed;
        this.cannonbal = cannonbal;
        this.damage = damage;
    }

    public void Fire(Transform[] gunPosition)
    {
        Fire(cannonbal, gunPosition);
    }

}
