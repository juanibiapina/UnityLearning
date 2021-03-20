using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMode : MonoBehaviour
{
    AsteroidSpawner spawner;

    void Awake() {
        spawner = FindObjectOfType<AsteroidSpawner>();
    }

    void Start()
    {

        for (int i = 0; i < 4; i++)
        {
            spawner.SpawnAsteroidInPlayArea(new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 2, new AsteroidSpec(1, 8, 0, null))));
        }

        StartCoroutine(SpawnAsteroidOnEdge());
    }

    IEnumerator SpawnAsteroidOnEdge()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            spawner.SpawnAsteroidOnEdge(new AsteroidSpec(4, 4, 2, new AsteroidSpec(2, 8, 2, new AsteroidSpec(1, 10, 0, null))));
        }
    }
}
