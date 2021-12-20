using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TEST : MonoBehaviour
{
    IShips[] shipTarget;
    void Start()
    {
        shipTarget[0] = FindObjectOfType<Izanami>();
        shipTarget[1] = FindObjectOfType<TestBoat>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shipTarget[0].Movement();
        shipTarget[0].BalanceBoat();
        shipTarget[1].Movement();
    }
    void Selector(IShips ship)
    {
        foreach (var item in shipTarget)
        {

        }
    }
}
