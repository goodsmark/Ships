using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MotherMainOfShips : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float speed = 100;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float angularSpeed = 500f;


    [Space(5f)]
    [Header("Reload")]
    [SerializeField] protected float maxReloadTime;
    [SerializeField] protected float reloadTimeL;
    [SerializeField] protected float reloadTimeR;
    
    [Space(5f)]
    [Header("Ammo")]
    [SerializeField] protected Cannonballs cannonbal;
    [SerializeField] protected Bomb bomb;

    public GUI gUI;
    
    protected Trajectory _trajectory;
    protected Transform _motor;
    protected Rigidbody _playerRB;
    protected Transform _trajectoryGO;


    protected byte stay = 0;
    protected bool isReloadedL;
    protected bool isReloadedR;

    protected Quaternion startMotorRotation;
    protected void Starter()
    {
        _playerRB = GetComponent<Rigidbody>();
        _motor = transform.Find("motor");
        _trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = _motor.localRotation;
        _trajectory = FindObjectOfType<Trajectory>();
    }
    protected void BalanceBoat()
    {
        if (_playerRB.transform.rotation.z > 0.60f || _playerRB.transform.rotation.z < -0.60f)
        {
            _playerRB.isKinematic = true;
            _playerRB.transform.rotation = Quaternion.Euler(_playerRB.transform.rotation.x, _playerRB.transform.rotation.y, 0);
            _playerRB.isKinematic = false;
        }
    }

    protected void Movement()
    {
        float moveY = Input.GetAxis("Horizontal");

        _playerRB.AddForceAtPosition(-moveY * _playerRB.transform.right * angularSpeed / 100f, _motor.position);

        var forward = Vector3.Scale(new Vector3(1, 0, 1), _playerRB.transform.forward);


        if (Input.GetKey(KeyCode.W))
            ApplyForceToReachVelocity(_playerRB, forward * speed, 5f);
        if (Input.GetKey(KeyCode.S))
            ApplyForceToReachVelocity(_playerRB, forward * -3f, 5f);


        _motor.SetPositionAndRotation(_motor.position, _playerRB.transform.rotation * startMotorRotation * Quaternion.Euler(0, 30f * moveY, 0));


        bool movingForward = Vector3.Cross(_playerRB.transform.forward, _playerRB.velocity).y < 0;

        _playerRB.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(_playerRB.velocity, (movingForward ? 1f : 0f) * _playerRB.transform.forward, Vector3.up) * 0.1f, Vector3.up) * _playerRB.velocity;


    }

    protected void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force)
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

    protected void Fire(ShipAmmunitions ammunitions, Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            ShipAmmunitions fire = Instantiate(ammunitions, roundPosition[i].transform.position, roundPosition[i].transform.rotation);
            fire.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * ammunitions.GetRoundSpeed();
            Destroy(fire.gameObject, 10f);
        }
    }
    protected void Fire(ShipAmmunitions ammunitions, Transform roundPosition)
    {
        ShipAmmunitions fire = Instantiate(ammunitions, roundPosition.transform.position, roundPosition.transform.rotation);
        fire.GetComponent<Rigidbody>().velocity = roundPosition.transform.forward * ammunitions.GetRoundSpeed();
        Destroy(fire.gameObject, 10f);
    }
    protected void Shooting() 
    {
        if (stay == 1)
        {
            if (isReloadedR)
            {
                Fire(cannonbal, _leftGuns);
                reloadTimeR = Mathf.Floor(0.00000f);
                isReloadedR = false;
            }

        }
        else if (stay == 2)
        {
            if (isReloadedL)
            {
                Fire(cannonbal, _leftGuns);
                reloadTimeL = Mathf.Floor(0.00000f);
                isReloadedL = false;
            }
        }



        if (stay == 1)
        {
            if (isReloadedR)
            {
                Fire(bomb, _leftGuns);
                reloadTimeR = Mathf.Floor(0.00000f);
                isReloadedR = false;
            }

        }
        else if (stay == 2)
        {
            if (isReloadedL)
            {
                Fire(bomb, _leftGuns);
                reloadTimeL = Mathf.Floor(0.00000f);
                isReloadedL = false;
            }
        }
        reloadTimeL = 0;
        print("44");
    }
}
