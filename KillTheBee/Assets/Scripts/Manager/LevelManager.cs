using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    [Header("PLAYER POSITION")] 
    [SerializeField] private List<Transform> playerPos = new List<Transform>();

    [Header("BEE INFORMATION BY LEVEL")] 
    [SerializeField] private List<Transform> beePos_level1 = new List<Transform>();
    [SerializeField] private List<int> beeHealth_level1 = new List<int>();
    
    [SerializeField] private List<Transform> beePos_level2 = new List<Transform>();
    [SerializeField] private List<int> beeHealth_level2 = new List<int>();
    
    [SerializeField] private List<Transform> beePos_level3 = new List<Transform>();
    [SerializeField] private List<int> beeHealth_level3 = new List<int>();

    private int currentLevel = 1;
    private int maxLevel = 3;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private LevelManager() {}

    public Transform getPlayerPosByLevel(int level)
    {
        return playerPos[level - 1];
    }

    public List<Transform> getBeePosByLevel(int level)
    {
        switch (level)
        {
            case 1: return beePos_level1; break;
            case 2: return beePos_level2; break;
            case 3: return beePos_level3; break;
        }

        return null;
    }
    
    public List<int> getBeeHealthByLevel(int level)
    {
        switch (level)
        {
            case 1: return beeHealth_level1; break;
            case 2: return beeHealth_level2; break;
            case 3: return beeHealth_level3; break;
        }

        return null;
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public void NextLevel()
    {
        if (currentLevel == maxLevel) currentLevel = 1;
        else currentLevel++;
    }
}
