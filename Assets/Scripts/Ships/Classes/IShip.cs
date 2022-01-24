using UnityEngine;

public interface IShips
{
    void Movement();
    void BalanceBoat();
    void WriteTrajectoryForSides();
    void Shooting();
    void RefreshTransformFireEffect();
}
