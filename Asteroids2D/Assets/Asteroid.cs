using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject part;

    float speed;

    void Start()
    { 
        speed = 8 / transform.localScale.x;

        // set random movement direction
        Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);

            if (part != null) {
                Instantiate(part, transform.position, transform.rotation);     
                Instantiate(part, transform.position, transform.rotation);
            }
        }
    }
}
