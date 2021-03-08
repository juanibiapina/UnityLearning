using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;

    private const int NUMBER_OF_ASTEROIDS = 5;
    Vector2 screenHalfSize;

    void Start()
    {
        CalculateScreenHalfSize();

        for (int i = 0; i < NUMBER_OF_ASTEROIDS; i++)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        // spawn
        Vector2 spawnPos = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), Random.Range(-screenHalfSize.y, screenHalfSize.y));
        GameObject e = Instantiate(asteroid, spawnPos, asteroid.transform.rotation);
        e.transform.parent = transform;

        // set random size
        float spawnSize = Random.Range(1, 5);
        e.transform.localScale = Vector2.one * spawnSize;

        // set random movement direction
        Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f , 1.0f));
        dir.Normalize();
        e.GetComponent<Rigidbody2D>().velocity = dir * 2;

    }

    void CalculateScreenHalfSize()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
}
