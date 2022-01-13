using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeavyShips : MotherMainOfShips
{
    [Header("Transform GUN`s of ship")]
    [SerializeField] protected Transform[] _leftGuns;
    [SerializeField] protected Transform[] _rightGuns;
    [SerializeField] protected Transform[] _upGuns;
    [SerializeField] protected Transform[] _downGuns;
    [SerializeField] protected Transform _artillery;
}
