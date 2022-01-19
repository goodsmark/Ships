using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fernand : HeavyShips, IShips, IGUI
{
    void Start()
    {
        base.Starter();
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
        gUI.SelectorWeapon();
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
        else
            stay = 0;

        Vector3 direction = Aiming.aiming.GetTransformAim() - _trajectoryGO.transform.position;
        _trajectoryGO.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 speed = _trajectoryGO.transform.forward * cannonbal.GetRoundSpeed();
        _trajectory.WriteTrajectory(_trajectoryGO.transform.position, speed);

    }
  
    public void Shooting()
    {
        base.Shooting(_leftGuns, _rightGuns);
    }
    public void Reload()
    {
        gUI.Reload(maxReloadTime, reloadTimeL, reloadTimeR);
        if (GUI.s == "c")
        {
            isReloadedL = false;
            isReloadedR = false;
            reloadTimeL = 0.00000f;
            reloadTimeR = 0.00000f;
            
        }
        if (GUI.s == "b")
        {
            isReloadedL = false;
            isReloadedR = false;
            reloadTimeL = Mathf.Floor(0.00000f);
            reloadTimeR = Mathf.Floor(0.00000f);
        }
        
    }
}
