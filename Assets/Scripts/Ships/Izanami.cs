using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Izanami : MonoBehaviour, IShips, ITrajectory
{
    public float speed =100f, maxSpeed, angularSpeed = 1000f;
    public Transform[] leftGuns;

   [SerializeField]Trajectory trajectory;
    Transform motor;
    Rigidbody _playerRB;

    protected Quaternion startMotorRotation;

    void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
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
        for (int i = 0; i < leftGuns.Length; i++)
        {
            Vector3 speed = leftGuns[i].transform.forward * 50f;
            trajectory.WriteTrajectory(leftGuns[i].transform.position, speed );
        }
        
    }
}
