using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChanger : MonoBehaviour
{
    public static SideChanger changer;
    Camera _camera;
    void Awake()
    {
        if (changer == null)
        {
            changer = this;
        }
        else
        {
            Destroy(this);
        }
        _camera = Camera.main;
    }
    public byte ChangeSide(Transform boat)
    {
        float angle = Vector3.SignedAngle(boat.transform.forward, _camera.transform.position - boat.transform.position, Vector3.up);
        if (angle < -45f && angle > -130f)
        {
            //Debug.Log("Cmotry na pravo");
            return 1;
        }
        else if (angle > 45f && angle < 130f)
        {
            //Debug.Log("Cmotry na levo");
            return 2;
        }
        return 0;
    }
}
