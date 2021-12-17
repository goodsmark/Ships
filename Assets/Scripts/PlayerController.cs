
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Transform steeringWheel;

    public float moveSpeed;
    public float rotateSpeed;
    public float Drag = 0.1f;

    private Quaternion _startRotation;
    private float _waterJetRotation_Y = 0f;
    [SerializeField] private Rigidbody _playerRB;
<<<<<<< HEAD
=======
    public BoatController boatController;
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    float force = 1;
    private void Awake()
    {
        _playerRB = player.GetComponent<Rigidbody>();
        _startRotation = steeringWheel.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    private void Update()
    {
       
       
    }
   
    void SteeringWheelRotate() {
        if (Input.GetKey(KeyCode.A))
        {
            _waterJetRotation_Y = steeringWheel.localEulerAngles.y + 1f;

            if (_waterJetRotation_Y > 50f && _waterJetRotation_Y < 270f)
            {
                _waterJetRotation_Y = 50f;
            }

            Vector3 newRotation = new Vector3(0f, _waterJetRotation_Y, 0f);

            steeringWheel.localEulerAngles = newRotation;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _waterJetRotation_Y = steeringWheel.localEulerAngles.y - 1f;

            if (_waterJetRotation_Y < 310f && _waterJetRotation_Y > 90f)
            {   
                _waterJetRotation_Y = 310f;
            }

            Vector3 newRotation = new Vector3(0f, _waterJetRotation_Y, 0f);

            steeringWheel.localEulerAngles = newRotation;
        }
    }
    void Movement() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        //_playerRB.AddRelativeForce(Vector3.forward * moveY * moveSpeed);
        //_playerRB.AddRelativeTorque(0f, moveX * rotateSpeed, 0f);

        var steer = 0;

        //steer direction [-1,0,1]
        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        if (Input.GetKey(KeyCode.W))
        {
            _playerRB.AddForce(forward * moveSpeed);
        }
        //Rotational Force
        _playerRB.AddForceAtPosition(steer * transform.right * moveSpeed / 100f, steeringWheel.position);
        var targetVel = Vector3.zero;
        steeringWheel.SetPositionAndRotation(steeringWheel.position, transform.rotation * _startRotation * Quaternion.Euler(0, 30f * steer, 0));

        var movingForward = Vector3.Cross(transform.forward, _playerRB.velocity).y < 0;

        //move in direction
        _playerRB.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(_playerRB.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * _playerRB.velocity;
        steeringWheel.Rotate(new Vector3(0f,0f,0f),0f);

    }
}