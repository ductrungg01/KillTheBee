using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmotionEffect : MonoBehaviour
{
    public float slowmotionFactor = 0.05f;
    public float slowmotionLength = 3f;

    private float slowmotionLengthRemain;
    private bool isSlowmotion = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (Time.unscaledDeltaTime > 0.2f) return;
        if (!isSlowmotion) return;
        
        slowmotionLengthRemain -= Time.unscaledDeltaTime;

        if (slowmotionLengthRemain <= 0)
        {
            Time.timeScale = 1;
            isSlowmotion = false;
        }
    }

    public void DoSlowmotionEffect()
    {
        Time.timeScale = slowmotionFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        
        slowmotionLengthRemain = slowmotionLength;
        isSlowmotion = true;
    }
}
