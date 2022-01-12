using UnityEngine;

public abstract class ShipAmmunitions : MonoBehaviour
{
    protected int Damage;
    protected float RoundSpeed;

    public void Fire(GameObject cannonbal,  Transform[] roundPosition)
    {
        for (int i = 0; i < roundPosition.Length; i++)
        {
            GameObject fire = Instantiate(cannonbal, roundPosition[i].transform.position, roundPosition[i].transform.rotation);
            fire.GetComponent<Rigidbody>().velocity = roundPosition[i].transform.forward * RoundSpeed;
            Destroy(fire.gameObject, 10f);
        }
    }
    public void Fire(GameObject round,  Transform roundPosition)
    {
        GameObject fire = Instantiate(round);
        fire.GetComponent<Rigidbody>().velocity = roundPosition.transform.forward * RoundSpeed;
        Destroy(fire.gameObject, 10f);
    }

}
