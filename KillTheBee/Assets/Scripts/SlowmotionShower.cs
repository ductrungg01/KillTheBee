using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowmotionShower : MonoBehaviour
{
    public SlowmotionEffect effect;
    public Text slowmotionText;

    private void Update()
    {
        if (effect.isActive == false)
        {
            slowmotionText.text = "";
        }
        else
        {
            int effectRemain = (int)(effect.slowmotionLengthRemain + 0.25f);
            slowmotionText.text = effectRemain.ToString();
        }
    }
}
