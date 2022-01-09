using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    public static float shootTimer;

    TEST player;
    IShips shipTarget;
    MotherMainOfShips shipsMain;
    public List<IShips> collectionsShip;
    IGUI gUI;

    void Start()
    {
        gUI = FindObjectOfType<Izanami>();
        collectionsShip = new List<IShips>();
        collectionsShip.Add(FindObjectOfType<Izanami>());
        //collectionsShip.Add(FindObjectOfType<Fernand>());
        shipsMain  = FindObjectOfType<Fernand>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var ship in collectionsShip)
        {
            Player.player_one.SWitchShip(ship);
        }

        if (shootTimer == 0f || shootTimer < 5f)
        {
            shootTimer += Time.deltaTime;
        }
        gUI.Reload();
        print(shootTimer);
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
