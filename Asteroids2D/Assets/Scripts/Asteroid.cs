using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject asteroid;
    public ParticleSystem explosion;

    public static event System.Action<GameObject> Destroyed;

    AsteroidSpawner spawner;
    AsteroidSpec spec;
    Rigidbody2D body;
    EndlessMode gameManager;

    int currentHP = 10;

    void Start() {
        spawner = FindObjectOfType<AsteroidSpawner>();
        body = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<EndlessMode>();
    }

    void FixedUpdate() {
        body.velocity = Vector2.ClampMagnitude(body.velocity, 12);
    }

    public void Initialize(AsteroidSpec spec) {
        this.spec = spec;

        this.currentHP = spec.hp;

        // calculate size
        transform.localScale = transform.localScale * spec.size;

        // calculate random velocity direction
        float angle = Random.value * Mathf.PI * 2;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().velocity = dir * spec.speed;
    }

    public void Damage(int damage) {
        currentHP -= damage;

        if (currentHP <= 0) {
            Destroy();
        }
    }

    void Destroy() {
        // create explosion
        explosion = Instantiate(explosion, transform.position, Quaternion.identity);
        explosion.transform.localScale = transform.localScale / 4;

        // spawn children
        if (spec.numberOfChildren > 0) {
            for (int i = 0; i < spec.numberOfChildren; i++) {
                Vector3 pos = Random.insideUnitCircle * (spec.size / 2);
                spawner.SpawnAsteroid(transform.position + pos, spec.childSpec);
            }
        }

        // emit event
        Destroyed?.Invoke(gameObject);

        // destroy self
        Destroy(gameObject);
    }
}
