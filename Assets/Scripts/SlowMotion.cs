using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public static SlowMotion slowMotion;
    void Start()
    {
        if (slowMotion == null)
        {
            slowMotion = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void StartSlowMo()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void StopSlowMo()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    
    }

}
