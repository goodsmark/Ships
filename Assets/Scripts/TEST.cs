using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    ITrajectory trajectory;
    IAmmunitionMain ammunitionMain;
    IShips shipTarget;
    IShips shipTarget1;
    void Start()
    {

        ammunitionMain = FindObjectOfType<Cannonballs>();
        shipTarget = FindObjectOfType<Izanami>();
        trajectory = FindObjectOfType<Izanami>();
        shipTarget1 = FindObjectOfType<TestBoat>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shipTarget.Movement();
        shipTarget.BalanceBoat();
        shipTarget1.Movement();
        shipTarget1.BalanceBoat();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ammunitionMain.Fire();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            trajectory.WriteTrajectory();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {

        }
        {
            //trajectory.
        }
    }
}
