using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    TEST player;
    IShips shipTarget;
    MotherMainOfShips shipsMain;
    void Start()
    {
        shipTarget = FindObjectOfType<Izanami>();
        shipsMain  = FindObjectOfType<Fernand>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Player.player_one.SWitchShip(shipTarget);
        

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
