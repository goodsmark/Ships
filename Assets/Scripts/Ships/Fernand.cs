using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fernand : MotherMainOfShips, IShips
{
    [Header("Movement")]
    public float speed = 100;
    public float maxSpeed;
    public float angularSpeed = 500f;

    [Space(5f)]

    [Header("Transform GUN`s of ship (LEft and Ride)")]
    [SerializeField] Transform[] _leftGuns;
    [SerializeField] Transform[] _rightGuns;

    Trajectory trajectory;
    Transform motor;
    Rigidbody _playerRB;
    Transform trajectoryGO;
    IAmmunitionMain ammunitionMain;
    MotherMainOfShips fernand;

    byte stay = 0;

    protected Quaternion startMotorRotation;
    void Awake()
    {
        fernand = this;
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = motor.localRotation;
        trajectory = FindObjectOfType<Trajectory>();
        ammunitionMain = FindObjectOfType<Cannonballs>();
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

        Vector3 direction = Aiming.aiming.GetTransformAim() - trajectoryGO.transform.position;
        trajectoryGO.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 speed = trajectoryGO.transform.forward * 200;
        trajectory.WriteTrajectory(trajectoryGO.transform.position, speed);

    }
    public void Fire()
    {
        if (stay == 1)
        {
            ammunitionMain.Fire(_rightGuns);
        }
        else if (stay == 2)
        {
            ammunitionMain.Fire(_leftGuns);
        }
    }
}
