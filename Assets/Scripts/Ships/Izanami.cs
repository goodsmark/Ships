using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MonoBehaviour, IShips, ITrajectory
{
    public float speed =100f, maxSpeed, angularSpeed = 1000f;
    public Transform[] leftGuns;

   [SerializeField]Trajectory trajectory;
    MotherMainOfShips motherMainOfShips;
    Transform motor;
    Rigidbody _playerRB;

    protected Quaternion startMotorRotation;

    void Awake()
    {
        motherMainOfShips = FindObjectOfType<MotherMainOfShips>();
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        startMotorRotation = motor.localRotation;
        trajectory = FindObjectOfType<Trajectory>();
    }

    public void Movement()
    {
        motherMainOfShips.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
    }

    public void BalanceBoat()
    {
        motherMainOfShips.BalanceBoat(_playerRB);
    }

    public void WriteTrajectory()
    {
        
        Vector3 speed = leftGuns[0].transform.forward * 50f;
        trajectory.WriteTrajectory(leftGuns[0].transform.position, speed );
    }
}
