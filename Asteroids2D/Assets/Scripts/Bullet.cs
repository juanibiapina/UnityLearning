using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float thrust;
    public float lifetime;

    void Start() {
        Destroy(gameObject, lifetime);
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * thrust);
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Asteroid") {
            // self destruct
            Destroy(gameObject);

            Asteroid asteroid = c.gameObject.GetComponent<Asteroid>();
            asteroid.Damage(10);
        }
    }
}
