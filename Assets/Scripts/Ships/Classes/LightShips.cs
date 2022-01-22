using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightShips : MotherMainOfShips
{
    [Header("Transform GUN`s of ship (LEft and Ride)")]
    [SerializeField] protected Transform[] _leftGuns;
    [SerializeField] protected Transform[] _rightGuns;

    protected void OnStart()
    {
        _poolFireEffects._poolCount += _leftGuns.Length + _rightGuns.Length;
    }
}
