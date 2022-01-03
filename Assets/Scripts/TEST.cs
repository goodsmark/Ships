using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    IShips shipTarget;
    void Start()
    {
        shipTarget = FindObjectOfType<Izanami>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shipTarget.Movement();
        shipTarget.BalanceBoat();
        if (Input.GetMouseButton(1))
        {
            shipTarget.WriteTrajectoryForSides();
            if (Input.GetKey(KeyCode.Mouse0))
            {
                shipTarget.Fire();
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {

        }
        {
            //trajectory.
        }
    }
}
