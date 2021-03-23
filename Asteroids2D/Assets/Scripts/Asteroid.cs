using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject asteroid;
    public ParticleSystem explosion;

    AsteroidSpawner spawner;
    AsteroidSpec spec;
    Rigidbody2D body;
    EndlessMode gameManager;
    Player player;

    int currentHP = 10;

    void Start() {
        spawner = FindObjectOfType<AsteroidSpawner>();
        body = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<EndlessMode>();
        player = FindObjectOfType<Player>();
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
        // destroy self
        Destroy(gameObject);

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

        // calculate points
        float playerFactor = Mathf.Max(1, player.GetComponent<Rigidbody2D>().velocity.magnitude);
        gameManager.AddPoints((int)(body.velocity.magnitude * (8 / transform.localScale.x) * playerFactor));
    }
}
