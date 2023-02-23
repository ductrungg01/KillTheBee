using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("TIME")] 
    public float startTime = 3f;
    public float endTime = 3f;
    
    [Header("== GAMEPLAY ==")]
    public GameObject playerInstance;
    
    
    [FormerlySerializedAs("bees")] [Header("ENEMY")]
    public GameObject beePrefab;
    public List<Transform> beePositions;

    [Header("CANVAS")] 
    public Text slowmotionText;
    
    [Header("EFFECTS")]
    public GameObject slowmotionEffect;
    
    private GameManager() {}

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameLoop();
    }

    void GameLoop()
    {
        GameStarting();
        GamePlaying();
        GameEnding();
    }

    async UniTask GameStarting()
    {
        SpawnEnemy();
        
        var effect = slowmotionEffect.GetComponent<SlowmotionEffect>();
        effect.slowmotionLength = startTime;
        
        effect.DoSlowmotionEffect();
    }

    async UniTask GamePlaying()
    {
        slowmotionText.text = "";
    }

    async UniTask GameEnding()
    {
        
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < beePositions.Count; i++)
        {
            Instantiate(beePrefab, beePositions[i].position, Quaternion.identity);
        }
    }
}
