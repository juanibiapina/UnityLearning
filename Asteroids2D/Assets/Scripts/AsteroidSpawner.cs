using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public GameObject asteroid;

    Vector2 screenHalfSize;

    void Awake() {
        CalculateScreenHalfSize();
    }
    public void SpawnAsteroidInPlayArea(AsteroidSpec spec) {
        SpawnAsteroid(DeterminePlayAreaSpawnPos(), spec);
    }

    public void SpawnAsteroidOnEdge(AsteroidSpec spec) {
        SpawnAsteroid(DetermineEdgeSpawnPos(), spec);
    }

    public void SpawnAsteroid(Vector2 position, AsteroidSpec spec) {
        GameObject e = Instantiate(asteroid, position, asteroid.transform.rotation);
        Asteroid n = e.GetComponent<Asteroid>();
        n.Initialize(spec);
        e.transform.parent = transform;
    }

    void CalculateScreenHalfSize() {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private Vector2 DeterminePlayAreaSpawnPos() {
        Vector2 spawnPos = new Vector2(Random.Range(2.5f, screenHalfSize.x - 2.5f), Random.Range(2.5f, screenHalfSize.y - 2.5f));
        bool flipX = (Random.value > 0.5f);
        bool flipY = (Random.value > 0.5f);

        if (flipX) {
            spawnPos.x *= -1;
        }

        if (flipY) {
            spawnPos.y *= -1;
        }

        return spawnPos;
    }

    private Vector2 DetermineEdgeSpawnPos() {
        Vector2 spawnPos;
        bool onSides = (Random.value > 0.5f);
        bool flip = (Random.value > 0.5f);

        if (onSides) {
            spawnPos = new Vector2(screenHalfSize.x + 2, Random.Range(-screenHalfSize.y - 2, screenHalfSize.y + 2));
            if (flip) {
                spawnPos.x *= -1;
            }
        } else {
            spawnPos = new Vector2(Random.Range(screenHalfSize.x + 2, -screenHalfSize.x - 2), screenHalfSize.y + 2);
            if (flip) {
                spawnPos.y *= -1;
            }
        }

        return spawnPos;
    }
}
