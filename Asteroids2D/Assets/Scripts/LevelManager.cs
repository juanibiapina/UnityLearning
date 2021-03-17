using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool nextLevel = false;

    // Update is called once per frame
    void Update()
    {
        if (nextLevel) {
            return;
        }

        int n = GameObject.FindGameObjectsWithTag("Asteroid").Length;
        if (n == 0)
        {
            nextLevel = true;
            Levels.NextLevel();
            Invoke("GoToLoadout", 2);
        }

    }

    void GoToLoadout()
    {
        SceneManager.LoadScene(1);
    }
}
