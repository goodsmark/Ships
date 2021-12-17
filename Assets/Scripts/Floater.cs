using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Transform[] floatersPoints;

    public float underWaterDrag = 1f, underWaterAngularDrag = 1f;
    public float airDrag = 0f, airAngularDrag = 0.05f;
<<<<<<< HEAD
    public float floatingPower = 15f;

    OceanManager oceanManager;
=======
    public float waterHeight = 0f;

    public float floatingPower = 15f;

>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    Rigidbody _rigidbody;

    int floatersUnderwater;

    bool underwater;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

<<<<<<< HEAD
=======
    // Update is called once per frame
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385
    void FixedUpdate()
    {
        floatersUnderwater = 0;
        for (int i = 0; i < floatersPoints.Length; i++)
        {
<<<<<<< HEAD
            float difference = floatersPoints[i].transform.position.y - OceanManager.instance.WaterHeightAtPositions(floatersPoints[i].position);
=======
            float difference = floatersPoints[i].transform.position.y - waterHeight;
>>>>>>> cceec04d45844bb66d75b25d3567bf2e7a40a385

            if (difference < 0)
            {
                _rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floatersPoints[i].transform.position, ForceMode.Force);
                floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchStateBody(true);
                }
            }
            if (underwater && floatersUnderwater == 0)
            {
                underwater = false;
                SwitchStateBody(false);

            }
        }
    }

    void SwitchStateBody(bool isUnderwater)
    {
        if (isUnderwater)
        {
            _rigidbody.drag = underWaterDrag;
            _rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            _rigidbody.drag = airDrag;
            _rigidbody.angularDrag = airAngularDrag;
        }
    }
}
