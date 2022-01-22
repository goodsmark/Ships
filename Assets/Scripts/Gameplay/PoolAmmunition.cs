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
    public ShipAmmunitions _mainAmmo;

    private PoolMono<Cannonballs> _poolCannonballs;
    private PoolMono<Bomb> _bombPool;
    public PoolMono<ShipAmmunitions> _poolShipAmmunitions;

    void Awake()
    {
        //_poolShipAmmunitions = new PoolMono<ShipAmmunitions>(_mainAmmo, _poolCount, transform);
        //_bombPool = new PoolMono<Bomb>(_bomb, _poolCount, transform);

        //_poolCannonballs.autoExpand = _autoExpand;
        //_bombPool.autoExpand = _autoExpand;
    }
    public void CreateAmmo(ShipAmmunitions ammo)
    {
        _poolShipAmmunitions = new PoolMono<ShipAmmunitions>(ammo, _poolCount, transform);
    }


}
