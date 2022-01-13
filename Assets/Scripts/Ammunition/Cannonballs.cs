using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cannonballs : ShipAmmunitions                   
{   
    [SerializeField]Rigidbody cannonbal;

    private void Awake()
    {
        cannonbal = GetComponent<Rigidbody>();
    }
}
