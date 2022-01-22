using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMainController : MonoBehaviour
{
    PlayerMainController player;
    IShips shipTarget;
    public List<IShips> collectionsShip;
    IGUI gUI;

    void Start()
    {
        gUI = FindObjectOfType<Fernand>();
        collectionsShip = new List<IShips>();
        collectionsShip.Add(FindObjectOfType<Izanami>());
        //collectionsShip.Add(FindObjectOfType<Fernand>());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var ship in collectionsShip)
        {
            SWitchShip(ship);
        }

        
        gUI.Reload();
        ShowMenuSelector();
    }
    public void SWitchShip(IShips player)
    {

        player.Movement();
        player.BalanceBoat();
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
}
