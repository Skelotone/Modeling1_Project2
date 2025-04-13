using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject playerPrefab;
    public GameObject lifeItemPrefab;
    public GameObject shieldItemPrefab;
    public GameObject scorePickUpPrefab;

    public GameObject gameOverText;
    public GameObject restartText;

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LivesText;
    
    private int score;

    private bool gameOver;

    public float horizontalScreenLimit = 11.25f;
    public float MaxY = -1f;
    public float MinY = -7f;

    void Start()
    {
        score = 0;
        gameOver = false;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        StartCoroutine(spawnPlayerItems());
        InvokeRepeating("createScorePickUp", 10f, 10f);

        InvokeRepeating("createEnemyOne", 1f, 3f);
        InvokeRepeating("createEnemyTwo", 1f, 2f);  
        InvokeRepeating("createEnemyThree", 1f, 1f);

    }

    void Update()
    {
      if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }  
    }

    void createEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-7f, 7f), 6f, 0), Quaternion.identity);
    }
    void createEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-10f, 10f), 6f, 0), Quaternion.identity);
    }
    void createEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-11f, 11f), 6f, 0), Quaternion.identity);
    }


void createScorePickUp()
    {
        float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
        float randomY = Random.Range(MinY, MaxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        Instantiate(scorePickUpPrefab, spawnPosition, Quaternion.identity);
    }
    IEnumerator spawnPlayerItems()
    {
        while (true)
        {
            // Wait for 20 seconds before spawning the next item
            yield return new WaitForSeconds(20f);

            // Generate a random position within the screen limits
            float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
            float randomY = Random.Range(MinY, MaxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            // Randomly select one of the player items to spawn
            int randomItem = Random.Range(0, 2); // Generates a random number between 0 and 2
            switch (randomItem)
            {
                case 0:
                    Instantiate(lifeItemPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(shieldItemPrefab, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    break; // No item spawned
            }
        }
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score.ToString();
    }
    public void UpdateLives(int lives)
    {
        LivesText.text = "" + lives.ToString();
    }
    
    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        Time.timeScale = 0f;
    }
    
}