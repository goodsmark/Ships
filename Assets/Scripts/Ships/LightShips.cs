using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightShips : MonoBehaviour
{
    [Header("Transform GUN`s of ship (LEft and Ride)")]
    [SerializeField] protected Transform[] _leftGuns;
    [SerializeField] protected Transform[] _rightGuns;
}
