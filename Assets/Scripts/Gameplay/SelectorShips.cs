
using UnityEngine;
using UnityEngine.UI;


public class SelectorShips : MonoBehaviour
{
    [SerializeField] CameraController _cameraController;
    public Image menuSelector;

    Camera _mainCamera;
    Rigidbody player;
    bool isPause= false;
    Quaternion cameraStartRotation;
    Vector3 cameraStartPosition;
    private void Start()
    {
        _mainCamera = Camera.main;
        menuSelector.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 cameraStartPosition = _mainCamera.transform.position;
        Quaternion cameraStartRotation = _mainCamera.transform.rotation;
        if (other.gameObject && other.gameObject.layer == 3 )
        {
            player = GetPlayer(other.gameObject);
            menuSelector.gameObject.SetActive(true);
            MenuSelector(0f, false);
            isPause = true;
            
        }
    }

    private void Update()
    {
        if (isPause)
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                print("sdsa");
                _mainCamera.transform.position = cameraStartPosition;
                _mainCamera.transform.rotation = cameraStartRotation;
                player.transform.position -= -Vector3.forward * 50f;
                menuSelector.gameObject.SetActive(false);
                MenuSelector(1f, true);
            }
        }
    }
    private Rigidbody GetPlayer(GameObject gameObject)
    {
        Rigidbody player = gameObject.GetComponent<Rigidbody>();
        return player;
    }
    void MenuSelector(float gameTime, bool cursorLocked)
    {
        Time.timeScale = gameTime;
        _cameraController.rotateAlways = cursorLocked;
        _cameraController.lockCursor = cursorLocked;
    }
}