using System.Collections;
using UnityEngine;

public abstract class ShipAmmunitions : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float RoundSpeed;
    [SerializeField] protected float lifetime = 5f;

    public float GetRoundSpeed()
    {
        return RoundSpeed;
    }
    public void TakeDamage(out int damage )
    {
        damage = Damage;
    }
    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }
    private void OnDisable()
    {
        StopCoroutine(LifeTime());
    }
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifetime);
        Deactivate();
    }
    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
