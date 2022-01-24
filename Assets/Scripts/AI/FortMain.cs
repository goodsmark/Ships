using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FortMain : MonoBehaviour
{
    [Header("Reload")]
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    [Space(5f)]
    [Header("Reload")]
    [SerializeField] protected Transform[] _gunsPositionFort;
    protected void Start()
    {
        health = maxHealth;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        int damage;
        if (collision.gameObject)
        {
            collision.gameObject.GetComponent<ShipAmmunitions>().TakeDamage(out damage);
            health -= damage;
            collision.gameObject.SetActive(false);
            if (health <= 0)
            {
                health = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
