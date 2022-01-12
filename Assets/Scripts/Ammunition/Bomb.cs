using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ShipAmmunitions
{
    [SerializeField] GameObject bomb;

    void Fire(Transform[] gunPosition)
    {
        Fire(bomb, gunPosition);
    }
}
