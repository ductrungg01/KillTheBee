using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SlowmotionEffect : MonoBehaviour
{
    public float slowmotionFactor = 0.05f;
    public float slowmotionLength = 3f;

    public float slowmotionLengthRemain;
    public bool isActive = false;

    private void Update()
    {
        if (Time.unscaledDeltaTime > 0.2f) return;
        if (!isActive) return;
        
        slowmotionLengthRemain -= Time.unscaledDeltaTime;

        if (slowmotionLengthRemain <= 0)
        {
            Time.timeScale = 1;
            isActive = false;
        }
    }

    public void DoSlowmotionEffect()
    {
        Time.timeScale = slowmotionFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        
        slowmotionLengthRemain = slowmotionLength;
        isActive = true;
    }
}
