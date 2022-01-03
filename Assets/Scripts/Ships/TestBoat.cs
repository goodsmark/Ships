using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class TestBoat : MotherMainOfShips, IShips
{
    public float speed = 50f, maxSpeed, angularSpeed = 500f;

    MotherMainOfShips motherMainOfShips;
    Transform motor;
    Rigidbody _playerRB;
    [SerializeField] Trajectory trajectory;

    protected Quaternion startMotorRotation;

    void Start()
    {
        motherMainOfShips = FindObjectOfType<MotherMainOfShips>();
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        startMotorRotation = motor.localRotation;
    }
    

    public void Movement()
    {
        motherMainOfShips.Movement(_playerRB, motor, startMotorRotation, angularSpeed, speed);
    }

    public void BalanceBoat()
    {
        motherMainOfShips.BalanceBoat(_playerRB);
    }

    public void WriteTrajectoryForSides()
    {
        throw new System.NotImplementedException();
    }

    public void TakeAim()
    {
        throw new System.NotImplementedException();
    }

    public void Fire()
    {
        throw new System.NotImplementedException();
    }
}
