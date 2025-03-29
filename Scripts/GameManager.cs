using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createEnemyOne", 1f, 3f);
        InvokeRepeating("createEnemyTwo", 1f, 2f);  
        InvokeRepeating("createEnemyThree", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-6f, 6f), 6f, 0), Quaternion.identity);
    }
    void createEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6f, 0), Quaternion.identity);
    }
    void createEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-9f, 9f), 6f, 0), Quaternion.identity);
    }
}
