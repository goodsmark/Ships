using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MonoBehaviour, IShips, ITrajectory
{
    public float speed =100f, maxSpeed, angularSpeed = 1000f;
    
    public Transform[] leftGuns;

    Trajectory trajectory;
    Transform motor;
    Rigidbody _playerRB;
    Transform trajectoryGO;

    protected Quaternion startMotorRotation;

    void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = motor.localRotation;
        trajectory = FindObjectOfType<Trajectory>();
    }

    public void Movement()
    {
        MotherMainOfShips.motherMainOfShips.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
    }

    public void BalanceBoat()
    {
        MotherMainOfShips.motherMainOfShips.BalanceBoat(_playerRB);
    }
    public void WriteTrajectory()
    {
        Vector3 direction = Aiming.aiming.GetTransformAim() - trajectoryGO.transform.position;
        trajectoryGO.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 speed = trajectoryGO.transform.forward * 200;
        trajectory.WriteTrajectory(trajectoryGO.transform.position, speed);

    }
    public void TakeAim()
    {
        Aiming.aiming.onAiming(leftGuns);
    }
    
}
