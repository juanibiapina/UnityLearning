using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject gameOverUi;
    bool gameOver;

    void Start() {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(0);
                Asteroid.dropChance = 0.05f;
            }
        }
    }

    void OnGameOver() {
        gameOver = true;
        gameOverUi.SetActive(true);
    }
}
