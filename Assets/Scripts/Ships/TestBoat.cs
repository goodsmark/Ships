using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoat : MonoBehaviour, IShips
{
    public float speed = 50f, maxSpeed, angularSpeed = 500f;

    Transform motor;
    Rigidbody _playerRB;
    [SerializeField] Trajectory trajectory;

    protected Quaternion startMotorRotation;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        motor = transform.Find("motor");
        startMotorRotation = motor.localRotation;
    }

    public void BalanceBoat()
    {
        if (_playerRB.transform.rotation.z > 0.60f || _playerRB.transform.rotation.z < -0.60f)
        {
            _playerRB.isKinematic = true;
            _playerRB.transform.rotation = Quaternion.Euler(_playerRB.transform.rotation.x, _playerRB.transform.rotation.y, 0);
            _playerRB.isKinematic = false;
        }
    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Horizontal");
        motor.SetPositionAndRotation(motor.position, transform.rotation * startMotorRotation * Quaternion.Euler(0, 30f * -moveY, 0));
        _playerRB.AddForceAtPosition(moveY * -transform.right * angularSpeed / 100f, motor.position);
        _playerRB.AddRelativeForce(Vector3.forward * moveX * speed);
    }
}
