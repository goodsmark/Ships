using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public static GUI Instantiate;
    public static string s = null;
    [Header("Slider`s for reload")]
    [Space(5f)]
    public Slider leftSlider;
    public Slider rightSlider;
    public Slider upSlider;
    public Slider downSlider;

    [Header("Selected weapon")]
    [Space(5f)]
    public Image pictureFrame;
    public Image cannonballImage;
    public Image bombImage;


    private void Start()
    {
        if (Instantiate == null)
        {
            Instantiate = this;
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
            leftSlider.gameObject.SetActive(true);
            leftSlider.maxValue = maxReloadTime;
            leftSlider.value = reloadTimeL;
        }
        else
            leftSlider.gameObject.SetActive(false);

        if (rightSlider != null)
        {
            rightSlider.gameObject.SetActive(true);
            rightSlider.maxValue = maxReloadTime;
            rightSlider.value = reloadTimeR;
        }
        else
            rightSlider.gameObject.SetActive(false);

        if (upSlider != null)
        {
            upSlider.gameObject.SetActive(true);
            upSlider.maxValue = maxReloadTime;
            upSlider.value = reloadTimeUp;
        }
        else
            upSlider.gameObject.SetActive(false);

        if (downSlider != null)
        {
            downSlider.gameObject.SetActive(true);
            downSlider.maxValue = maxReloadTime;
            downSlider.value = reloadTimeDown;
        }
        else
            downSlider.gameObject.SetActive(false);

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
