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
    public void Reload(float maxReloadTime, float reloadTimeL = 1, float reloadTimeR = 1, float reloadTimeUp = 1, float reloadTimeDown = 1) 
    {
        if (leftSlider != null)
        {
            leftSlider.gameObject.active = true;
            leftSlider.maxValue = maxReloadTime;
            leftSlider.value = reloadTimeL;
        }
        else
            leftSlider.gameObject.active = false;

        if (rightSlider != null)
        {
            rightSlider.gameObject.active = true;
            rightSlider.maxValue = maxReloadTime;
            rightSlider.value = reloadTimeR;
        }
        else
            rightSlider.gameObject.active = false;

        if (upSlider != null)
        {
            upSlider.gameObject.active = true;
            upSlider.maxValue = maxReloadTime;
            upSlider.value = reloadTimeUp;
        }
        else
            upSlider.gameObject.active = false;

        if (downSlider != null)
        {
            downSlider.gameObject.active = true;
            downSlider.maxValue = maxReloadTime;
            downSlider.value = reloadTimeDown;
        }
        else
            downSlider.gameObject.active = false;

    } 
}
