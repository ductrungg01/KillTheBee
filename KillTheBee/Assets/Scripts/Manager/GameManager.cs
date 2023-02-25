using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("BEE")]
    public GameObject beePrefab;
    private List<Transform> beePos = new List<Transform>();
    private List<int> beeHealth = new List<int>();

    [Header("CANVAS")] 
    public Text slowmotionText;
    public Text tutorialText;
    public Text levelText;
    public Text gameplayText;
    
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

    private async void GameLoop()
    {
        await GameStarting();
        await GamePlaying();
        await GameEnding();

        if (IsPlayerDead())
        {
            SceneManager.LoadScene("Game Scene");
        }
        else
        {
            GameLoop();
        }
    }

    private async UniTask GameStarting()
    {
        Debug.Log("Start");
        gameplayText.text = "";
        levelText.text = "Level " + LevelManager.Instance.getCurrentLevel().ToString();
        tutorialText.text = "Tap the bees on the screen to kill them";
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
        tutorialText.text = "Ready!";
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        tutorialText.text = "GO!";
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        tutorialText.text = "";
        levelText.text = "";

        Setup();
        SpawnEnemy();
        
        // Do slow motion
        var effect = slowmotionEffect.GetComponent<SlowmotionEffect>();
        effect.slowmotionLength = startTime;
        effect.DoSlowmotionEffect();
        
        await UniTask.Delay(TimeSpan.FromSeconds(startTime));
    }

    private async UniTask GamePlaying()
    {
        slowmotionText.text = "";
        tutorialText.text = "";
        levelText.text = "";

        while (!IsPlayerDead() && !NoEnemyLeft())
        {
            await UniTask.Yield();
        }
    }

    private async UniTask GameEnding()
    {
        if (IsPlayerDead())
        {
            gameplayText.text = "GAMEOVER!";
        }
        else
        {
            gameplayText.text = "You win!";
        }
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
        
        // Go to next level
        LevelManager.Instance.NextLevel();
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < beePos.Count; i++)
        {
            GameObject bee =  Instantiate(beePrefab, beePos[i].position, Quaternion.identity);
            bee.GetComponent<Bee>().SetHealth(beeHealth[i]);
            
            BeeManager.Instance.bees.Add(bee);
        }
    }

    private void Setup()
    {
        BeeManager.Instance.bees.Clear();
        
        int currentLevel = LevelManager.Instance.getCurrentLevel();
        Transform playerPos = LevelManager.Instance.getPlayerPosByLevel(currentLevel);
        this.beePos = LevelManager.Instance.getBeePosByLevel(currentLevel);
        this.beeHealth = LevelManager.Instance.getBeeHealthByLevel(currentLevel);

        this.playerInstance.transform.position = playerPos.position;
    }

    bool IsPlayerDead()
    {
        return this.playerInstance.GetComponent<Player>().isDead;
    }

    bool NoEnemyLeft()
    {
        for (int i = 0; i < BeeManager.Instance.bees.Count; i++)
        {
            if (BeeManager.Instance.bees[i].activeSelf == true)
            {
                return false;
            }
        }
        
        return true;
    }
    
}
