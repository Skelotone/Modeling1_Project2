using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float swaySpeed = 2f; // Speed of sway
    private float swayAmount;  // Amount of sway
    private float startX;  // Starting X position

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x; // Store the initial X position
        swayAmount = Random.Range(1f, 5f); // Randomize the sway speed between 1 and 2
    }

    // Update is called once per frame
    void Update()
    {
       // Calculate new X position based on sine wave
      float newX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
      // Update the position with the new X value 
      transform.position = new Vector3(startX + newX, transform.position.y, transform.position.z);
      // Move the enemy downwards
      transform.Translate(Vector3.down * Time.deltaTime * 2f);
      // Check if the enemy is out of bounds
      if (transform.position.y < -8f)
      {
          Destroy(gameObject);
      }  
    }
private void OnTriggerEnter2D(Collider2D whatdidihit)
    {
        if (whatdidihit.tag == "Player")
        {
            whatdidihit.GetComponent<Player>().LooseALife();
            Destroy(this.gameObject); 

        }
        if (whatdidihit.tag == "Bullet")
        {
            Destroy(whatdidihit.gameObject);
            Destroy(this.gameObject); 
            GameManager.instance.AddScore(10);
        }
    }
}
