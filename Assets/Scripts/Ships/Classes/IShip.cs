using UnityEngine;

public interface IShips
{
    Vector3 GetPosition();
    void Movement();
    void BalanceBoat();
    void WriteTrajectoryForSides();
    void Shooting();
    void RefreshTransformFireEffect();
}
