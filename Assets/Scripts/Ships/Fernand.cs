using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fernand : MotherMainOfShips, IShips, IGUI
{
    [Header("Movement")]
    public float speed = 100;
    public float maxSpeed;
    public float angularSpeed = 500f;

    [Space(5f)]

    [Header("Transform GUN`s of ship (LEft and Ride)")]
    [SerializeField] Transform[] _leftGuns;
    [SerializeField] Transform[] _rightGuns;

    [Space(5f)]
    [Header("Ammo")]
    public float maxReloadTime;
    public float reloadTimeL;
    public float reloadTimeR;

    public GUI gUI;

    Trajectory trajectory;
    Transform motor;
    Rigidbody _playerRB;
    Transform trajectoryGO;
    IAmmunitionMain ammunitionMain;
    MotherMainOfShips fernand;
    Cannonballs cannonbal;
    Bomb bomb;

    byte stay = 0;
    bool isReloadedL;
    bool isReloadedR;

    protected Quaternion startMotorRotation;
    void Awake()
    {
        fernand = this;
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        trajectoryGO = transform.Find("Trajectory"); 
        startMotorRotation = motor.localRotation;
        trajectory = FindObjectOfType<Trajectory>();
        cannonbal = FindObjectOfType<Cannonballs>();
        bomb = FindObjectOfType<Bomb>();
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

    public void Movement()
    {
        fernand.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
    }

    public void BalanceBoat()
    {
        fernand.BalanceBoat(_playerRB);
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

        Vector3 direction = Aiming.aiming.GetTransformAim() - trajectoryGO.transform.position;
        trajectoryGO.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 speed = trajectoryGO.transform.forward * cannonbal.GetRoundSpeed();
        trajectory.WriteTrajectory(trajectoryGO.transform.position, speed);

    }
    //public void Fire()
    //{
       
    //    if (stay == 1)
    //    {
    //        if (isReloadedR)
    //        {
    //            cannonbal.Fire(_rightGuns);
    //            reloadTimeR = Mathf.Floor(0.00000f);
    //            isReloadedR = false;
    //        }

    //    }
    //        else if (stay == 2)
    //    {
    //        if (isReloadedL)
    //        {
    //            cannonbal.Fire(_leftGuns);
    //            reloadTimeL = Mathf.Floor(0.00000f);
    //            isReloadedL = false;
    //        }
    //    }


       
    //    if (stay == 1)
    //    {
    //        if (isReloadedR)
    //        {
    //            bomb.Fire(_rightGuns);
    //            reloadTimeR = Mathf.Floor(0.00000f);
    //            isReloadedR = false;
    //        }

    //    }
    //    else if (stay == 2)
    //    {
    //        if (isReloadedL)
    //        {
    //            bomb.Fire(_leftGuns);
    //            reloadTimeL = Mathf.Floor(0.00000f);
    //            isReloadedL = false;
    //        }
    //    }
    //    reloadTimeL = 0;
    //    print("44");
    //}
    public void Fire()
    {
        base.Fire(cannonbal, _leftGuns, cannonbal.GetRoundSpeed());       
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
