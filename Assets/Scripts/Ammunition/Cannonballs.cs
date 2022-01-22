using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cannonballs : ShipAmmunitions                   
{
    [SerializeField] float lifetime = 5f;

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
