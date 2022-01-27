using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public static Aiming aiming;

    [SerializeField] float _aimOffsetY;
    [SerializeField] Transform aimForGun;
    Camera _MainCamera;
    RaycastHit hit;
    void Awake()
    {
        if (aiming == null)
        {
            aiming = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        _MainCamera = Camera.main;
    }

    public void onAiming(Transform gunPosition)
    {
        Ray ray = _MainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = (aimForGun.transform.position + Vector3.up * _aimOffsetY) - gunPosition.transform.position;
        gunPosition.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        //float distance = Vector3.Distance(aimForGun.transform.position, gunPosition.transform.position);
        if (Physics.Raycast(ray, out hit))
        {
            aimForGun.position = ray.origin + ray.direction * _aimOffsetY;
        }
        else
        {
            aimForGun.position = ray.origin + ray.direction * _aimOffsetY;
        }
    }
    public void onAiming(Transform[] gunPosition)
    {
        Ray ray = _MainCamera.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < gunPosition.Length; i++)
        {
            Vector3 direction = aimForGun.transform.position - gunPosition[i].transform.position;
            gunPosition[i].transform.rotation = Quaternion.LookRotation(direction, -Vector3.forward);
            //float distance = Vector3.Distance(aimForGun.transform.position, gunPosition[i].transform.position);
        }
        if (Physics.Raycast(ray, out hit))
        {
            aimForGun.position = ray.origin + ray.direction * _aimOffsetY;
        }
        else
        {
            aimForGun.position = ray.origin + ray.direction * _aimOffsetY;
        }
    }
    public Vector3 GetTransformAim() => aimForGun.transform.position;

}
