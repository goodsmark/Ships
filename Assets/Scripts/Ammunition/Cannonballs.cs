using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonballs : ShipAmmunitions                   
{   
    [SerializeField]GameObject cannonbal;

    public void Fire(Transform[] gunPosition)
    {

        Fire(cannonbal, gunPosition);
    }

}
