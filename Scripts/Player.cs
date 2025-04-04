using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Player Movment
    public int lives;
    public float playerSpeed;
    private GameManager gameManager;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 11.25f;
    private float MaxY = -1f;
    private float MinY = -7f;

    public GameObject bulletPrefab;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3; // Set the initial number of lives
        gameManager.UpdateLives(lives); 
    }
    
    void Update()
    {
        //Call the function to read input
        Movement();
        Shooting();
    }

    public void LooseALife()
    {
        lives--;
        gameManager.UpdateLives(lives);
        if (lives <= 0)
        {
            //Game Over
            Destroy(this.gameObject);
        }
    }
    public void GainALife()
    {
        if (lives < 3)
        {
            lives++;
            gameManager.UpdateLives(lives);
        }
        else
        {
            gameManager.AddScore(1000);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * playerSpeed * Time.deltaTime);

        //player colides with screen horizontaly
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        //player colides with vertical screen limits
        if (transform.position.y > MaxY)
        {
            transform.position = new Vector3(transform.position.x, MaxY, 0);
        }
        else if (transform.position.y < MinY)
        {
            transform.position = new Vector3(transform.position.x, MinY, 0);
        }
    }
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate the bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
