using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;

    Vector2 screenHalfSize;

    void Start()
    {
        CalculateScreenHalfSize();

        foreach (AsteroidSpec spec in Levels.SpecsForCurrentLevel())
        {
            SpawnAsteroid(DetermineSpawnPos(), spec);
        }
    }

    public void SpawnAsteroid(Vector2 position, AsteroidSpec spec)
    {
        GameObject e = Instantiate(asteroid, position, asteroid.transform.rotation);
        Asteroid n = e.GetComponent<Asteroid>();
        n.Initialize(spec);
        e.transform.parent = transform;
    }

    private Vector2 DetermineSpawnPos()
    {
        Vector2 spawnPos = new Vector2(Random.Range(2.5f, screenHalfSize.x - 2.5f), Random.Range(2.5f, screenHalfSize.y - 2.5f));
        bool flipX = (Random.value > 0.5f);
        bool flipY = (Random.value > 0.5f);

        if (flipX)
        {
            spawnPos.x *= -1;
        }

        if (flipY)
        {
            spawnPos.y *= -1;
        }

        return spawnPos;
    }

    void CalculateScreenHalfSize()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
}
