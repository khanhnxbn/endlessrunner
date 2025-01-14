using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{

    // ANOTHER APPROACH: UNITY EVENT
    public GameObject player;
    public GameObject gameOverUI;
    public Spawner spawner; 

    #region Singleton...

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    private void Update()
    {
     if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }   
     
    }

    public void StartGame()
    {
        {
            player.SetActive(true);
            isPlaying = true;
            spawner.laterobstaclespeed = spawner.obstacleSpeed;
            spawner.laterobstacletime = spawner.obstacleSpawnTime;
            spawner.timealive = 0;
        }
    }
    public void GameOver()
    {
        currentScore = 0;
        isPlaying = false;
        gameOverUI.SetActive(true);
        spawner.ClearObstacle();
       
    }
    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    
}