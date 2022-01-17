using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player_one;
    public List<IShips> ships;
    private void Start()
    {
        if (player_one == null)
        {
            player_one = this;
        }
        else if (true)
        {
            Destroy(this);
        }
    }
    public void SWitchShip(IShips player) {

        player.Movement();
        player.BalanceBoat();
        if (Input.GetMouseButton(1))
        {
            player.WriteTrajectoryForSides();
            if (Input.GetKey(KeyCode.Mouse0))
            {
                player.Shooting();
            }
        }
    }
}
