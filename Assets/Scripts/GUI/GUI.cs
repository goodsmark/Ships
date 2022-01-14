using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public static GUI gUI;
    public static string s = null;
    [Header("Slider`s for reload")]
    [Space(5f)]
    public Slider leftSlider;
    public Slider rightSlider;
    public Slider upSlider;
    public Slider downSlider;

    [Header("Slider`s for reload")]
    [Space(5f)]
    public Image pictureFrame;
    public Image cannonballImage;
    public Image bombImage;


    public Image panel;

    private void Start()
    {
        panel.gameObject.SetActive(false);
        if (gUI == null)
        {
            gUI = this;
        }
        else
        {
            Destroy(this);
        }

        pictureFrame.gameObject.SetActive(false);
    }
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
    public void SelectorWeapon()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            s = "c";
            print("нажата 1");
            pictureFrame.gameObject.transform.position = cannonballImage.transform.position;
            pictureFrame.gameObject.SetActive(true);
            //cannonballImage.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            s = "b";
            print("нажата 4");
            pictureFrame.gameObject.transform.position = bombImage.transform.position;
            pictureFrame.gameObject.SetActive(true);
            //cannonballImage.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
    }
}
