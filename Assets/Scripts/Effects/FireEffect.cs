using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    [SerializeField] float lifetime = 4f;

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
