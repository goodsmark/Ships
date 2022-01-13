using UnityEngine;

public abstract class ShipAmmunitions : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float RoundSpeed;

    public float GetRoundSpeed()
    {
        return RoundSpeed;
    }
    public void TakeDamage()
    {

    }
}
