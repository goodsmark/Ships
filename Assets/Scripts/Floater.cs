using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Transform[] floatersPoints;

    public float underWaterDrag = 1f, underWaterAngularDrag = 1f;
    public float airDrag = 0f, airAngularDrag = 0.05f;
    public float floatingPower = 15f;

    Rigidbody _rigidbody;

    int _floatersUnderwater;

    bool underwater;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _floatersUnderwater = 0;
        for (int i = 0; i < floatersPoints.Length; i++)
        {
            float difference = floatersPoints[i].transform.position.y - OceanManager.instance.WaterHeightAtPositions(floatersPoints[i].position);

            if (difference < 0)
            {
                _rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floatersPoints[i].transform.position, ForceMode.Force);
                _floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchStateBody(true);
                }
            }
            if (underwater && _floatersUnderwater == 0)
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
