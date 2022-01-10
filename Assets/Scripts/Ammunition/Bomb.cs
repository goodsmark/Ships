using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ShipAmmunitions
{
    // Start is called before the first frame update
    int damage;
    float roundSpeed;
    [SerializeField] GameObject bomb;

    public Bomb(int damage, float roundSpeed, GameObject bomb) : base(damage, roundSpeed)
    {
        this.roundSpeed = roundSpeed;
        this.bomb = bomb;
        this.damage = damage;
    }
}
