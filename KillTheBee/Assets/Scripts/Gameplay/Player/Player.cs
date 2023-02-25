using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bee"))
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
    }
}
