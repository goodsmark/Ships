using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Slider slider;
    public void Reload(float maxReloadTime, float reloadTime) 
    {
        slider.maxValue = maxReloadTime;
        slider.value = reloadTime;
    } 
}
