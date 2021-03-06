using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MediumShips : MotherMainOfShips
{
    [Header("Transform GUN`s of ship (LEft and Ride)")]
    [SerializeField] protected Transform[] _leftGuns;
    [SerializeField] protected Transform[] _rightGuns;
    [SerializeField] protected Transform[] _upGuns;
    [SerializeField] protected Transform[] _downGuns;

    protected void OnStart()
    {
        _poolFireEffects._poolCount += _leftGuns.Length + _rightGuns.Length + _upGuns.Length + _downGuns.Length;
    }
} 
