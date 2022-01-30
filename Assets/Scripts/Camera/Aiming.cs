using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Aiming : MonoBehaviour
{
    public static Aiming aiming;

    [SerializeField] float _aimOffset;
    [SerializeField] float _aimDistance;
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
        Vector3 direction = (aimForGun.transform.position + Vector3.up * _aimOffset) - gunPosition.transform.position;
        gunPosition.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);

        if (Physics.Raycast(ray, out hit))
        {
            aimForGun.position = ray.origin + ray.direction * _aimOffset;
        }
        else
        {
            aimForGun.position = ray.origin + ray.direction * _aimOffset;
        }
    }
    public void onAiming(Transform[] gunPosition)
    {
        float distance;
        Ray ray = _MainCamera.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < gunPosition.Length; i++)
        {
            //distance = Vector3.Distance(aimForGun.transform.position, gunPosition[i].transform.position);
            Vector3 direction = aimForGun.transform.position - gunPosition[i].transform.position;
            gunPosition[i].transform.rotation = Quaternion.LookRotation(direction, -Vector3.forward);
            if (Physics.Raycast(ray, out hit, _aimDistance))
            {
                aimForGun.position = ray.origin + ray.direction * _aimOffset;
            }
            else
            {
                aimForGun.position = ray.origin + ray.direction * _aimOffset;
            }
        }
        
    }
        
    public Vector3 GetTransformAim() => aimForGun.transform.position;

}
