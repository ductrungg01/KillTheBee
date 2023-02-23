using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        if (health > 1)
        {
            healthText.text = health.ToString();
        }
    }

    public void Hit()
    {
        health--;
        healthText.text = health.ToString();

        if (health == 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
