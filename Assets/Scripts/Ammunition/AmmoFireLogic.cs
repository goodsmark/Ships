using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoFireLogic : MonoBehaviour
{
    public static AmmoFireLogic ammoFireLogic;

    private void Awake()
    {
        if (ammoFireLogic == null)
        {
            ammoFireLogic = this;
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
