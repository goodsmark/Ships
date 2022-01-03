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
        float moveY = Input.GetAxis("Horizontal");
        
        rigidbody.AddForceAtPosition(-moveY * rigidbody.transform.right * angularSpeed / 100f, motor.position);

        var forward = Vector3.Scale(new Vector3(1, 0, 1), rigidbody.transform.forward);


        if (Input.GetKey(KeyCode.W))
            ApplyForceToReachVelocity(rigidbody, forward * speed, 5f);
        if (Input.GetKey(KeyCode.S))
            ApplyForceToReachVelocity(rigidbody, forward * -3f, 5f);


        motor.SetPositionAndRotation(motor.position, rigidbody.transform.rotation * startMotorRotation * Quaternion.Euler(0, 30f * moveY, 0));


        bool movingForward = Vector3.Cross(rigidbody.transform.forward, rigidbody.velocity).y < 0;

        rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(rigidbody.velocity, (movingForward ? 1f : 0f) * rigidbody.transform.forward, Vector3.up) * 0.1f, Vector3.up) * rigidbody.velocity;


    }

    public void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force)
    {
        if (force == 0 || velocity.magnitude == 0)
            return;

        velocity = velocity + velocity.normalized * 0.2f * rigidbody.drag;

        force = Mathf.Clamp(force, -rigidbody.mass / Time.fixedDeltaTime, rigidbody.mass / Time.fixedDeltaTime);

        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.AddForce(velocity * force, mode);
        }
        else
        {
            var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
            rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
        }
    }
}
