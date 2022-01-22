using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolFireEffects : MonoBehaviour
{
    [Space(5f)]
    [Header("PoolEffect")]
    [SerializeField] protected bool _autoExpand = false;
    public FireEffect _fireEffect;
    [HideInInspector] public PoolMono<FireEffect> _poolFireEffects;
    [HideInInspector] public int _poolCount = 100;

    void Awake()
    {
        _poolFireEffects = new PoolMono<FireEffect>(_fireEffect, _poolCount, transform);
        _poolFireEffects.autoExpand = _autoExpand;
    }
}
