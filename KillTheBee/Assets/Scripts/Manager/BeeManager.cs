using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    public static BeeManager Instance;
    
    public List<GameObject> bees = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
}
