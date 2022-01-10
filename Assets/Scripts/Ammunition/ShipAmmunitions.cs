using UnityEngine;

public abstract class ShipAmmunitions : MonoBehaviour
{
    public int damage;
    public float roundSpeed;

    protected ShipAmmunitions(int damage, float roundSpeed) 
    {
        this.damage = damage;
        this.roundSpeed = roundSpeed;
    }

    public void Fire(GameObject cannonbal,  Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            GameObject fire = Instantiate(cannonbal, roundPosition[i].transform.position, roundPosition[i].transform.rotation);
            fire.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * roundSpeed;
            Destroy(fire.gameObject, 10f);
        }
    }
    public void Fire(GameObject round,  Transform roundPosition)
    {
        GameObject fire = Instantiate(round, roundPosition.transform.position, roundPosition.transform.rotation);
        fire.GetComponent<Rigidbody>().velocity = roundPosition.transform.forward * roundSpeed;
        Destroy(fire.gameObject, 10f);
    }

}
