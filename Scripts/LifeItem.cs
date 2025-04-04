using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    private float horizontalScreenLimit = 11.25f;
    private float MaxY = -1f;
    private float MinY = -7f;

    void Start()
    {
        float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
        float randomY = Random.Range(MinY, MaxY);
        transform.position = new Vector3(randomX, randomY, transform.position.z);

        Destroy(gameObject, 5f); // Destroy the item if not collected
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().GainALife();
            Destroy(gameObject);
        }
    }
}
