using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MotherMainOfShips : MonoBehaviour
{
    public static MotherMainOfShips motherMainOfShips;

    private void Awake()
    {
        if (motherMainOfShips == null)
        {
            motherMainOfShips = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void BalanceBoat(Rigidbody rigidbody)
    {
        if (rigidbody.transform.rotation.z > 0.60f || rigidbody.transform.rotation.z < -0.60f)
        {
            rigidbody.isKinematic = true;
            rigidbody.transform.rotation = Quaternion.Euler(rigidbody.transform.rotation.x, rigidbody.transform.rotation.y, 0);
            rigidbody.isKinematic = false;
        }
    }

    public void Movement(Rigidbody rigidbody, Transform motor, Quaternion startMotorRotation, float angularSpeed, float speed)
    {
        float moveX = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Horizontal");
        motor.SetPositionAndRotation(motor.position, transform.rotation * startMotorRotation * Quaternion.Euler(0, 30f * -moveY, 0));
        rigidbody.AddForceAtPosition(moveY * -transform.right * angularSpeed / 10f, motor.position);
        rigidbody.AddRelativeForce(Vector3.forward * moveX * speed, ForceMode.Impulse);
    }
}
