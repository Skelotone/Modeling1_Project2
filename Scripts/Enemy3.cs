using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.down * Time.deltaTime * 10f);
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
            GameManager.instance.AddScore(100);
        }
    }
}