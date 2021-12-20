using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed, maxSpeed, angularSpeed;

    [SerializeField] Transform motor;
    [SerializeField] Rigidbody _playerRB;
    [SerializeField] Trajectory trajectory;


    protected Quaternion startMotorRotation;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        startMotorRotation = motor.localRotation;
    }

   
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
        }

        Movement();
        BalanceBoat(_playerRB.transform.rotation.z);
    }

    void Movement()
    {
        float moveX = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Horizontal");
        motor.SetPositionAndRotation(motor.position, transform.rotation * startMotorRotation * Quaternion.Euler(0, 30f * -moveY, 0));
        _playerRB.AddForceAtPosition(moveY * -transform.right * angularSpeed / 100f, motor.position);
        _playerRB.AddRelativeForce(Vector3.forward *moveX * speed);

    }

    void BalanceBoat(float transRotationZ)
    {
        if (transRotationZ > 0.60f || transRotationZ < -0.60f)
        {
            _playerRB.isKinematic = true;
            _playerRB.transform.rotation = Quaternion.Euler(_playerRB.transform.rotation.x, _playerRB.transform.rotation.y, 0);
            _playerRB.isKinematic = false;
        }
    }
    
    
}
