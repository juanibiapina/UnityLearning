﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public static float dropChance = 0.05f;

    public GameObject asteroid;
    public ParticleSystem explosion;
    public GameObject[] drops;

    AsteroidSpawner spawner;
    AsteroidSpec spec;
    Rigidbody2D body;

    int currentHP = 10;

    void Start() {
        spawner = FindObjectOfType<AsteroidSpawner>();
        body = GetComponent<Rigidbody2D>();
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

        // create drop or increase chance for next time
        if (Random.value < dropChance) {
            int n = Random.Range(0, drops.Length);
            Instantiate(drops[n], transform.position, Quaternion.identity);
        } else {
            dropChance += 0.05f;
        }

        // spawn children
        if (spec.numberOfChildren > 0) {
            for (int i = 0; i < spec.numberOfChildren; i++) {
                Vector3 pos = Random.insideUnitCircle * (spec.size / 2);
                spawner.SpawnAsteroid(transform.position + pos, spec.childSpec);
            }
        }
    }
}
