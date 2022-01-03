using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChanger : MonoBehaviour
{
    Camera _camera;
    void Awake()
    {
        _camera = Camera.main;
    }
    public int ChangeSide(Transform boat)
    {
        float angle = Vector3.SignedAngle(boat.transform.forward, _camera.transform.position - boat.transform.position, Vector3.up);
        print(angle);
        if (angle < -45f && angle > -130f)
        {
            Debug.Log("Cmotry na pravo");
            return 1;
        }
        else if (angle > 45f && angle < 130f)
        {
            Debug.Log("Cmotry na levo");
            return 2;
        }
        return 0;
    }
}
