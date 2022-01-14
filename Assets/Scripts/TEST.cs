using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    TEST player;
    IShips shipTarget;
    public List<IShips> collectionsShip;
    IGUI gUI;

    void Start()
    {
        gUI = FindObjectOfType<Fernand>();
        collectionsShip = new List<IShips>();
        //collectionsShip.Add(FindObjectOfType<Izanami>());
        collectionsShip.Add(FindObjectOfType<Fernand>());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var ship in collectionsShip)
        {
            Player.player_one.SWitchShip(ship);
        }

        
        gUI.Reload();
        if (Input.GetKeyDown(KeyCode.T))
        {
            GUI.gUI.panel.gameObject.SetActive(true);
            SlowMotion.slowMotion.StartSlowMo();
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            GUI.gUI.panel.gameObject.SetActive(false);
            SlowMotion.slowMotion.StopSlowMo();
        }
        print(Time.timeScale);
        print(Time.fixedDeltaTime);

        //shipTarget.Movement();
        //shipTarget.BalanceBoat();
        //if (Input.GetMouseButton(1))
        //{
        //    shipTarget.WriteTrajectoryForSides();
        //    if (Input.GetKey(KeyCode.Mouse0))
        //    {
        //        shipTarget.Fire();
        //    }
        //}
        //else if (Input.GetMouseButtonUp(1))
        //{

        //}
        //{
        //    //trajectory.
        //}
    }
}
