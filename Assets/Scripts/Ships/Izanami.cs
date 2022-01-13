using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MotherMainOfShips, IShips, IGUI
{
    [Header("Movement")]
    
    public float speed = 100f;
    public float maxSpeed;
    public float angularSpeed = 1000f;
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
    ShipAmmunitions cannonbal;
    MotherMainOfShips izanami;

    byte stay = 0;

    protected Quaternion startMotorRotation;

    void Awake()
    {
        izanami = this;
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = motor.localRotation;
        trajectory = FindObjectOfType<Trajectory>();
        cannonbal = FindObjectOfType<Cannonballs>();
    }

    void Update()
    {
        if (reloadTimeL < maxReloadTime)
        {
            reloadTimeL += Time.deltaTime;
            
        }
        if (reloadTimeR < maxReloadTime)
        {
            reloadTimeR += Time.deltaTime;
        }

    }

    public void Movement()
    {
        izanami.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
    }

    public void BalanceBoat()
    {
        izanami.BalanceBoat(_playerRB);
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

        Vector3 direction = Aiming.aiming.GetTransformAim() - trajectoryGO.transform.position;
        trajectoryGO.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 speed = trajectoryGO.transform.forward * 200;
        trajectory.WriteTrajectory(trajectoryGO.transform.position, speed);

    }
    public void Fire()
    {
        if (stay == 1)
        {
            if (reloadTimeR >= maxReloadTime)
            {
                //cannonbal.Fire(_rightGuns);
                reloadTimeR = 0;
            }
            
        }
        else if (stay == 2)
        {
            if (reloadTimeL >= maxReloadTime)
            {
                //cannonbal.Fire(_leftGuns);
                reloadTimeL = 0;
            }
        }
    }

    public void Reload()
    {
        gUI.Reload(maxReloadTime, reloadTimeL, reloadTimeR);
    }
}
