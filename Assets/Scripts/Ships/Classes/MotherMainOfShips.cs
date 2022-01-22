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
    protected bool isReloadedUp;
    protected bool isReloadedDown;
    [Header("Pool")]
    protected PoolFireEffects _poolFireEffects;
    protected PoolAmmunition _poolAmmunition;

    protected Quaternion startMotorRotation;

    
    protected void Starter()
    {
        _playerRB = GetComponent<Rigidbody>();
        _motor = transform.Find("motor");
        _trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = _motor.localRotation;
        _trajectory = FindObjectOfType<Trajectory>();
        _poolFireEffects = FindObjectOfType<PoolFireEffects>();
        _poolAmmunition = FindObjectOfType<PoolAmmunition>();
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

        velocity += velocity.normalized * 0.2f * rigidbody.drag;

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
            _poolAmmunition._mainAmmo.transform.position = roundPosition[i].position;
            _poolAmmunition._mainAmmo = _poolAmmunition._poolShipAmmunitions.GetFreeElement();
            _poolAmmunition.CreateAmmo(ammunitions);
            _poolAmmunition._mainAmmo.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * ammunitions.GetRoundSpeed();


        }
        //for (int i = 0; i < roundPosition.Length; i++)
        //{
        //    ShipAmmunitions firePref = Instantiate(ammunitions, roundPosition[i].transform.position, roundPosition[i].transform.rotation);
            
        //    firePref.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * ammunitions.GetRoundSpeed();

        //    Destroy(firePref.gameObject, 10f);
        //}
    }
    protected void FireEffects(Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            _poolFireEffects._fireEffect.transform.position = roundPosition[i].position;
            _poolFireEffects._fireEffect = _poolFireEffects._poolFireEffects.GetFreeElement();
        }
    }

    protected void Shooting(Transform[] gunPositionL, Transform[] gunPositionR, Transform[] gunPositionUp = null, Transform[] gunPositionDown = null) 
    {
        if (stay == 1)
        {
            if (isReloadedR)
            {
                Fire(cannonbal, gunPositionR);
                FireEffects(gunPositionR);
                reloadTimeR = Mathf.Floor(0.00000f);
                isReloadedR = false;
            }

        }
        else if (stay == 2)
        {
            if (isReloadedL)
            {
                Fire(cannonbal, gunPositionL);
                FireEffects(gunPositionL);
                reloadTimeL = Mathf.Floor(0.00000f);
                isReloadedL = false;
            }
        }



        if (stay == 1)
        {
            if (isReloadedR)
            {
                Fire(bomb, gunPositionR);
                reloadTimeR = Mathf.Floor(0.00000f);
                isReloadedR = false;
            }

        }
        else if (stay == 2)
        {
            if (isReloadedL)
            {
                Fire(bomb, gunPositionL);
                reloadTimeL = Mathf.Floor(0.00000f);
                isReloadedL = false;
            }
        }
    }
}
