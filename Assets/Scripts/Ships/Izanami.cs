using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MediumShips, IShips, IGUI
{
    void Awake()
    {
        Starter();
    }

    void Update()
    {
        if (reloadTimeL < maxReloadTime || isReloadedR == false)
        {
            reloadTimeL += Time.deltaTime;
        }
        if (reloadTimeR < maxReloadTime || isReloadedL == false)
        {
            reloadTimeR += Time.deltaTime;
        }
        if (reloadTimeL >= maxReloadTime)
        {
            isReloadedL = true;
        }
        if (reloadTimeR >= maxReloadTime)
        {
            isReloadedR = true;
        }
    }

    public new void Movement()
    {
        base.Movement();
    }

    public new void BalanceBoat()
    {
        base.BalanceBoat();
    }
    public void WriteTrajectoryForSides()
    {
        stay = SideChanger.changer.ChangeSide(_playerRB.transform);
        if (stay == 1)
        {
            Aiming.aiming.onAiming(_rightGuns);
        }
        else if (stay == 2)
        {
            Aiming.aiming.onAiming(_leftGuns);
        }

        Vector3 direction = Aiming.aiming.GetTransformAim() - _trajectoryGO.transform.position;
        _trajectoryGO.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 speed = _trajectoryGO.transform.forward * 200;
        _trajectory.WriteTrajectory(_trajectoryGO.transform.position, speed);

    }
    //public void Shooting()
    //{
    //    if (stay == 1)
    //    {
    //        if (reloadTimeR >= maxReloadTime)
    //        {
    //            //cannonbal.Fire(_rightGuns);
    //            reloadTimeR = 0;
    //        }

    //    }
    //    else if (stay == 2)
    //    {
    //        if (reloadTimeL >= maxReloadTime)
    //        {
    //            //cannonbal.Fire(_leftGuns);
    //            reloadTimeL = 0;
    //        }
    //    }
    //}
    public void Shooting()
    {
        base.Shooting(_leftGuns, _rightGuns);
    }

    public void Reload()
    {
        gUI.Reload(maxReloadTime, reloadTimeL, reloadTimeR);
    }
}
