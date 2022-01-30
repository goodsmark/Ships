using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAmmunition : MonoBehaviour
{
    [Header("PoolAmmo")]
    [SerializeField] int _poolCount;
    [SerializeField] bool _autoExpand = false;
    public Cannonballs _cannonballs;
    public Bomb _bomb;

    public PoolMono<Cannonballs> _poolCannonballs;
    public PoolMono<Bomb> _bombPool;

    void Start()
    {
        _poolCannonballs = new PoolMono<Cannonballs>(_cannonballs, _poolCount, transform);
        _bombPool = new PoolMono<Bomb>(_bomb, _poolCount, transform);

        _poolCannonballs.autoExpand = _autoExpand;
        _bombPool.autoExpand = _autoExpand;
    }
}
