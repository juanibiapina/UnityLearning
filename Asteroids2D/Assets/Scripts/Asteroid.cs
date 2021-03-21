﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject asteroid;
    public ParticleSystem explosion;
    public GameObject drop;

    AsteroidSpawner spawner;
    AsteroidSpec spec;

    int currentHP = 10;

    void Start() {
        spawner = FindObjectOfType<AsteroidSpawner>();
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

        // create drop
        if (Random.value < 0.05) {
            Instantiate(drop, transform.position, Quaternion.identity);
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
