using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Aiming : MonoBehaviour
{
    public static Aiming aiming;

    [SerializeField] Vector3 _aimOffset;
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

    public void onAiming(Transform[] gunPosition)
    {
        Ray ray = _MainCamera.ScreenPointToRay(Input.mousePosition + _aimOffset);
        for (int i = 0; i < gunPosition.Length; i++)
        {
            //distance = Vector3.Distance(aimForGun.transform.position, gunPosition[i].transform.position);
            Vector3 direction = aimForGun.transform.position - gunPosition[i].transform.position;
            gunPosition[i].transform.rotation = Quaternion.LookRotation(direction, -Vector3.forward);
            if (Physics.Raycast(ray, out hit, _aimDistance))
            {
                aimForGun.transform.position = hit.point;
            }
            else
            {
                aimForGun.transform.position = ray.origin + ray.direction * _aimDistance;
            }
        }
        
    }
        
    public Vector3 GetTransformAim() => aimForGun.transform.position;

}
