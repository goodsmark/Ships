using UnityEngine;

public interface IShips
{
    Vector3 GetPosition();
    void Movement();
    void BalanceBoat();
    void WriteTrajectoryForSides();
    void HideTrajectoryForSides();
    void Shooting();
    void RefreshTransformFireEffect();

}
