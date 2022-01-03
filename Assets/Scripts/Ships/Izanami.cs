using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MonoBehaviour, IShips
{
    public float speed =100f, maxSpeed, angularSpeed = 1000f;
    
    public Transform[] leftGuns;
    public Transform[] rightGuns;

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
        // MotherMainOfShips.motherMainOfShips.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
        if (Input.GetKey(KeyCode.W))
        {
            _playerRB.AddRelativeForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _playerRB.AddRelativeTorque(Vector3.up * speed);
        }


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
            Aiming.aiming.onAiming(rightGuns);
        }
        else if (stay == 2)
        {
            Aiming.aiming.onAiming(leftGuns);
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
            ammunitionMain.Fire(rightGuns);
        }
        else if (stay == 2)
        {
            ammunitionMain.Fire(leftGuns);
        }
    }


}
