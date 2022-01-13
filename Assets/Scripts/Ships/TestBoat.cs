using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class TestBoat
{
    public float speed = 50f, maxSpeed, angularSpeed = 500f;

    MotherMainOfShips motherMainOfShips;
    Transform motor;
    Rigidbody _playerRB;
    [SerializeField] Trajectory trajectory;

    protected Quaternion startMotorRotation;

    void Start()
    {

        startMotorRotation = motor.localRotation;
    }
    


}
