using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMainController : MonoBehaviour
{
    public static PlayerMainController _instantiate;
    public Transform _playerPoint;
    [SerializeField] CameraController _cameraController;
    Camera _maincamera;
    public List<IShips> collectionsShip;
    IGUI gUI;

    void Awake()
    {
        if (_instantiate == null)
        {
            _instantiate = this;
        }
        else
        {
            Destroy(this);
        }
        _maincamera = Camera.main;
        gUI = FindObjectOfType<Izanami>();
        collectionsShip = new List<IShips>();
        collectionsShip.Add(FindObjectOfType<Izanami>());
        //collectionsShip.Add(FindObjectOfType<Fernand>());
        
    }

    void FixedUpdate()
    {
        foreach (var ship in collectionsShip)
        {
            SWitchShip(ship);
            _playerPoint.position = ship.GetPosition();
        }
    }
    private void Update()
    {
        gUI.Reload();
        ShowMenuSelector();
        SwhowCursor();
        

    }
    public void SWitchShip(IShips player)
    {
        player.Movement();
        player.BalanceBoat();
        player.RefreshTransformFireEffect();
        if (Input.GetMouseButton(1))
        {
            player.WriteTrajectoryForSides();

            if (Input.GetMouseButton(0))
            {
                player.Shooting();
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //player.
        }
    }
    void ShowMenuSelector()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GUI.Instantiate.menuSelector.gameObject.SetActive(true);
            SlowMotion.slowMotion.StartSlowMo();
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            GUI.Instantiate.menuSelector.gameObject.SetActive(false);
            SlowMotion.slowMotion.StopSlowMo();
        }
    }
    void SwhowCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _cameraController.rotateAlways = false;
            _cameraController.lockCursor = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _cameraController.rotateAlways = true;
            _cameraController.lockCursor = true;
        }
    }
}
