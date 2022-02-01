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
     protected float reloadTimeL;
     protected float reloadTimeR;
    [Space(5f)]
    [Header("Reload Between Shoot")]
    [SerializeField] protected float minReloadBtwShoot;
    [SerializeField] protected float maxReloadBtwShoot;
    protected float timeToReadyFire;
    [Space(5f)]
    [Header("Sounds 0f fire")]
    [SerializeField] protected AudioSource[] fireFounds;


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

    protected SailState _sailState;
    bool IsPressedButtonW;
    bool IsPressedButtonS;
    protected enum SailState : sbyte
    {
        Reverse = -1,
        Zero,
        FirstGear,
        SecondGear,
        ThirdGear
    }

    protected void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _motor = transform.Find("motor");
        _trajectoryGO = transform.Find("Trajectory");
        startMotorRotation = _motor.localRotation;
        _trajectory = FindObjectOfType<Trajectory>();
        _poolFireEffects = FindObjectOfType<PoolFireEffects>();
        _poolAmmunition = FindObjectOfType<PoolAmmunition>();
        _sailState = SailState.Zero;
    }
    protected void FixedUpdate()
    {
        ReloadTimer();

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
        IsPressedButtonW = false;
        IsPressedButtonS = false;
        float moveY = Input.GetAxisRaw("Horizontal");
        IsPressedButtonW = Input.GetKeyUp(KeyCode.W);
        IsPressedButtonS = Input.GetKeyUp(KeyCode.S);

        if (IsPressedButtonW && _sailState != SailState.ThirdGear)
        {

            _sailState++;
            IsPressedButtonW = false;
        }
        if (IsPressedButtonS)
        {
            if (_sailState == SailState.Reverse)
            {
                return;
            }
            else
            {
                _sailState--;
            }
            IsPressedButtonS = false;
        }

        switch (_sailState)
        {
            case SailState.Reverse:
                _playerRB.AddRelativeForce(Vector3.forward * -speed/2f);
                break;
            case SailState.Zero:
                _playerRB.AddRelativeForce(Vector3.zero);
                break;
            case SailState.FirstGear:
                _playerRB.AddRelativeForce(Vector3.forward * speed);
                break;
            case SailState.SecondGear:
                _playerRB.AddRelativeForce(Vector3.forward * speed * 2);
                break;
            case SailState.ThirdGear:
                _playerRB.AddRelativeForce(Vector3.forward * speed * 3);
                break;
        }


        _playerRB.AddForceAtPosition(-moveY * _playerRB.transform.right * angularSpeed / 100f, _motor.position);

    }

    void ReloadTimer()
    {
        if (reloadTimeL < maxReloadTime || isReloadedL == false)
        {
            reloadTimeL += Time.deltaTime;
        }
        if (reloadTimeR < maxReloadTime || isReloadedR == false)
        {
            reloadTimeR += Time.deltaTime;
        }
        if (reloadTimeL >= maxReloadTime)
        {
            isReloadedL = true;
        }
        if (reloadTimeR >= maxReloadTime)
        {
            isReloadedR = true;
        }
    }


    IEnumerator FireWithDelay(Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            int playRandomFireShoot = Random.RandomRange(0, fireFounds.Length);
            timeToReadyFire = Random.Range(minReloadBtwShoot, maxReloadBtwShoot);
            _poolFireEffects._fireEffect.transform.position = roundPosition[i].position;
            _poolFireEffects._fireEffect = _poolFireEffects._poolFireEffects.GetFreeElement();
            _poolAmmunition._cannonballs = _poolAmmunition._poolCannonballs.GetFreeElement();
            _poolAmmunition._cannonballs.transform.position = roundPosition[i].position;
            _poolAmmunition._cannonballs.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * cannonbal.GetRoundSpeed();
            
             fireFounds[playRandomFireShoot].Play();



            yield return new WaitForSeconds(timeToReadyFire);
        }
        yield break;
    }

    public void RefreshTransformFireEffect(Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            _poolFireEffects._fireEffect.transform.position = roundPosition[i].position;
        }
    }

    protected void Shooting(Transform[] gunPositionL, Transform[] gunPositionR, Transform[] gunPositionUp = null, Transform[] gunPositionDown = null) 
    {
        if (stay == 1)
        {
            if (isReloadedR)
            {
                StartCoroutine(FireWithDelay(gunPositionR));
                reloadTimeR = Mathf.Floor(0.00000f);
                isReloadedR = false;
            }

        }
        else if (stay == 2)
        {
            if (isReloadedL)
            {
                StartCoroutine(FireWithDelay(gunPositionL));
                reloadTimeL = Mathf.Floor(0.00000f);
                isReloadedL = false;
            }
        }
    }
}
