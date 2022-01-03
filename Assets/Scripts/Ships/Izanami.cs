using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MonoBehaviour, IShips
{
    public float speed =100f, maxSpeed, angularSpeed = 1000f;
    
    [SerializeField] Transform[] _leftGuns;
    [SerializeField] Transform[] _rightGuns;

    Trajectory trajectory;
    Transform motor;
    Rigidbody _playerRB;
    Transform trajectoryGO;
    IAmmunitionMain ammunitionMain;

    byte stay = 0;

    protected Quaternion startMotorRotation;

    void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = motor.localRotation;
        trajectory = FindObjectOfType<Trajectory>();
        ammunitionMain = FindObjectOfType<Cannonballs>();
    }

    public void Movement()
    {
        MotherMainOfShips.motherMainOfShips.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
    }

    public void BalanceBoat()
    {
        MotherMainOfShips.motherMainOfShips.BalanceBoat(_playerRB);
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
