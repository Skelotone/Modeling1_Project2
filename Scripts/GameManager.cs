using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject playerPrefab;
    public GameObject lifeItemPrefab;
    public GameObject scorePickUpPrefab;

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LivesText;
    
    private int score;

    public float horizontalScreenLimit = 11.25f;
    public float MaxY = -1f;
    public float MinY = -7f;

    void Start()
    {
        score = 0;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("createLifeItem", 30f, 30f);
        InvokeRepeating("createScorePickUp", 10f, 10f);

        InvokeRepeating("createEnemyOne", 1f, 3f);
        InvokeRepeating("createEnemyTwo", 1f, 2f);  
        InvokeRepeating("createEnemyThree", 1f, 1f);

    }

    void Update()
    {
        
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

void createLifeItem()
    {
        float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
        float randomY = Random.Range(MinY, MaxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        Instantiate(lifeItemPrefab, spawnPosition, Quaternion.identity);
    }
void createScorePickUp()
    {
        float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
        float randomY = Random.Range(MinY, MaxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        Instantiate(scorePickUpPrefab, spawnPosition, Quaternion.identity);
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
}
