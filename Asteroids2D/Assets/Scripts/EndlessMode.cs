using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessMode : MonoBehaviour {
    public GameObject gameOverUi;
    public Text scoreValueText;
    public Text highScoreValueText;

    public Text scoreValueTextInGame;

    AsteroidSpawner spawner;
    private int score;
    bool gameOver;

    void Awake() {
        spawner = FindObjectOfType<AsteroidSpawner>();
    }

    void Start() {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;

        for (int i = 0; i < 4; i++) {
            spawner.SpawnAsteroidInPlayArea(new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 2, new AsteroidSpec(1, 8, 0, null))));
        }

        StartCoroutine(SpawnAsteroidOnEdge());
    }

    // Update is called once per frame
    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver() {
        gameOver = true;

        // display game over UI
        gameOverUi.SetActive(true);

        // set score
        scoreValueText.text = score.ToString();

        // set high score
        highScoreValueText.text = CalculateHighScore().ToString();

        // reset score
        score = 0;
    }

    IEnumerator SpawnAsteroidOnEdge() {
        while (true) {
            yield return new WaitForSeconds(4);
            spawner.SpawnAsteroidOnEdge(new AsteroidSpec(4, 4, 2, new AsteroidSpec(2, 8, 2, new AsteroidSpec(1, 10, 0, null))));
        }
    }

    public void AddPoints(int value) {
        score += value;
        scoreValueTextInGame.text = score.ToString();
    }

    public int CalculateHighScore() {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        return highScore;
    }
}
