using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MediumShips, IShips, IGUI
{
    private void Start()
    {
        base.Start();
        OnStart();
    }
    public Vector3 GetPosition()
    {
       return this.transform.position;
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
        _trajectory.gameObject.SetActive(true);
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
        Vector3 speed = _trajectoryGO.transform.forward * cannonbal.GetRoundSpeed();
        _trajectory.WriteTrajectory(_trajectoryGO.transform.position, speed);
    }
    public void HideTrajectoryForSides()
    {
        _trajectory.gameObject.SetActive(false);
    }

    public void Shooting()
    {
        base.Shooting(_leftGuns, _rightGuns);
    }

    public void Reload()
    {
        gUI.Reload(maxReloadTime, reloadTimeL, reloadTimeR);
    }
    public void RefreshTransformFireEffect()
    {
        if (stay == 1)
        {
            base.RefreshTransformFireEffect(_rightGuns);
        }
        else if (stay == 2)
        {
            base.RefreshTransformFireEffect(_leftGuns);
        }
    }


}
