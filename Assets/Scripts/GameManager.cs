using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] Dinosaur dinosaur;
    [SerializeField] Spawner spawner;
    [SerializeField] CloudSpawner cloudSpawner;

    private const string BestScoreKey = "BestScore";

    void Awake()
    {
    PlayerPrefs.DeleteKey(BestScoreKey);
    PlayerPrefs.Save();

    FindObjectOfType<UIManager>().UpdateBestScoreDisplay();
    }

    public void NewGame()
    {
        gameOver.SetActive(false);

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach(var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        dinosaur.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        cloudSpawner.gameObject.SetActive(true);

        dinosaur.StartMovement();

        Global.maxSpawnDelay = 3f;

        spawner.StartSpawning();
        cloudSpawner.StartSpawningClouds();

        Global.score = 0;
        Global.gameSpeed = 5;
        Global.isPaused = false;
        enabled = true;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);

        dinosaur.gameObject.SetActive(true);
        spawner.gameObject.SetActive(false);
        cloudSpawner.gameObject.SetActive(false);

        spawner.CancelSpawn();
        cloudSpawner.StopCloudSpawning();

        dinosaur.StopMovement();

        int currentScore = Mathf.FloorToInt(Global.score);
        int BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        
        if (currentScore > BestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, currentScore);
            PlayerPrefs.Save();
        }

        FindObjectOfType<UIManager>().UpdateBestScoreDisplay();

        Global.isPaused = true;
        Global.gameSpeed = 0;
        enabled = false;
    }
}
