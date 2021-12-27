using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionMain : MonoBehaviour
{
    public static AmmunitionMain ammunitionMain;

    private void Awake()
    {
        if (ammunitionMain == null)
        {
            ammunitionMain = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void Fire(GameObject round, float roundSpeed, Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            GameObject fire = Instantiate(round, roundPosition[i].transform.position, roundPosition[i].transform.rotation);
            fire.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * roundSpeed;
            Destroy(fire.gameObject, 10f);
        }
    }
    public void Fire(GameObject round, float roundSpeed, Transform roundPosition)
    {
        GameObject fire = Instantiate(round, roundPosition.transform.position, roundPosition.transform.rotation);
        fire.GetComponent<Rigidbody>().velocity = roundPosition.transform.forward * roundSpeed;
        Destroy(fire.gameObject, 10f);
    }
}
