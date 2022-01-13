using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : ShipAmmunitions
{
    [SerializeField] GameObject bomb;

    private void Start()
    {
        bomb = GetComponent<GameObject>();
    }
}

