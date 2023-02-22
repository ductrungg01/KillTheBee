using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("TIME")] 
    public float startTime = 3f;
    public float endTime = 3f;
    
    [Header("== GAMEPLAY ==")]
    public GameObject playerInstance;
    public List<GameObject> bees;
    
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
        var effect = slowmotionEffect.AddComponent<SlowmotionEffect>();
        effect.slowmotionLength = startTime;
        
        effect.DoSlowmotionEffect();
    }

    async UniTask GamePlaying()
    {
        
    }

    async UniTask GameEnding()
    {
        
    }
}
