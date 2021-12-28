using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    ITrajectory trajectory;
    IAmmunitionMain ammunitionMain;
    IShips shipTarget;
    Izanami izanami;
    void Start()
    {
        izanami = FindObjectOfType<Izanami>();
        ammunitionMain = FindObjectOfType<Cannonballs>();
        shipTarget = FindObjectOfType<Izanami>();
        trajectory = FindObjectOfType<Izanami>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shipTarget.Movement();
        shipTarget.BalanceBoat();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ammunitionMain.Fire();
        }
        if (Input.GetMouseButton(1))
        {
            trajectory.WriteTrajectory();
            izanami.TakeAim();
        }
        else if (Input.GetMouseButtonUp(1))
        {

        }
        {
            //trajectory.
        }
    }
}
