using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public enum ItemType
    {
        Life,
        Shield,
        Score
    }

    public ItemType itemType; // Specify the type of item in the Inspector
    public int scoreAmount = 100; // Default score amount for Score items
    public AudioClip pickupSound; // Sound to play when picked up

    private float horizontalScreenLimit = 11.25f;
    private float MaxY = -1f;
    private float MinY = -7f;

    void Start()
    {
        // Set a random position within the screen limits
        float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
        float randomY = Random.Range(MinY, MaxY);
        transform.position = new Vector3(randomX, randomY, transform.position.z);

        // Destroy the item if not collected within 5 seconds
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Play the pickup sound
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Perform the action based on the item type
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                switch (itemType)
                {
                    case ItemType.Life:
                        player.GainALife();
                        break;
                    case ItemType.Shield:
                        player.GainAShield();
                        break;
                    case ItemType.Score:
                        GameManager.instance.AddScore(scoreAmount);
                        break;
                }
            }

            // Destroy the item after it is collected
            Destroy(gameObject);
        }
    }
}