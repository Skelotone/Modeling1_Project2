using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.up * Time.deltaTime * 10f);

        // Destroy the bullet after 1.5 seconds
        Destroy(gameObject, 1.5f);
    }
}
