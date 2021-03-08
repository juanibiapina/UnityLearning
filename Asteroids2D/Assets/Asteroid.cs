using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject part;

    float speed;

    void Start()
    {
        // calculate speed from size
        speed = 8 / transform.localScale.x;

        // calculate random velocity direction
        float angle = Random.value * Mathf.PI * 2;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
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

            if (part != null)
            {
                float offset = part.transform.localScale.x / 2;
                Instantiate(part, new Vector2(transform.position.x - offset, transform.position.y - offset), Quaternion.identity);
                Instantiate(part, new Vector2(transform.position.x + offset, transform.position.y + offset), Quaternion.identity);
            }
        }
    }
}
