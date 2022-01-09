using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Slider leftSlider;
    public Slider rightSlider;
    public Slider upSlider;
    public Slider downSlider;
    public void Reload(float maxReloadTime, float reloadTimeL = 0, float reloadTimeR = 0, float reloadTimeUp = 0, float reloadTimeDown = 0) 
    {
        if (leftSlider != null)
        {
            leftSlider.maxValue = maxReloadTime;
            leftSlider.value = reloadTimeL;
        }
        if (rightSlider != null)
        {
            rightSlider.maxValue = maxReloadTime;
            rightSlider.value = reloadTimeR;
        }
        if (upSlider != null)
        {
            upSlider.maxValue = maxReloadTime;
            upSlider.value = reloadTimeUp;
        }
        if (downSlider != null)
        {
            downSlider.maxValue = maxReloadTime;
            downSlider.value = reloadTimeDown;
        }
    } 
}
