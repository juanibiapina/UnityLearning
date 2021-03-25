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
    Player player;
    EventSystem eventSystem;
    private int score;
    bool gameOver;

    void Awake() {
        spawner = FindObjectOfType<AsteroidSpawner>();
        player = FindObjectOfType<Player>();
        eventSystem = FindObjectOfType<EventSystem>();
    }

    void OnEnable() {
        eventSystem.AsteroidDestroyed += AsteroidDestroyed;
        eventSystem.PlayerDied += GameOver;
    }

    void OnDisable() {
        eventSystem.AsteroidDestroyed -= AsteroidDestroyed;
        eventSystem.PlayerDied -= GameOver;
    }

    void Start() {
        for (int i = 0; i < 4; i++) {
            spawner.SpawnAsteroidInPlayArea(new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 2, new AsteroidSpec(1, 8, 0, null))));
        }

        StartCoroutine(SpawnAsteroidOnEdge());
    }

    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(1);
            }
        }
    }

    void AsteroidDestroyed(GameObject asteroid) {
        float playerFactor = Mathf.Max(1, player.GetComponent<Rigidbody2D>().velocity.magnitude);
        AddPoints((int)(asteroid.GetComponent<Rigidbody2D>().velocity.magnitude * (8 / transform.localScale.x) * playerFactor));
    }

    void GameOver() {
        gameOver = true;

        // display game over UI
        gameOverUi.SetActive(true);

        // set score
        scoreValueText.text = score.ToString();

        // save and show high score
        highScoreValueText.text = CalculateHighScore().ToString();
    }

    IEnumerator SpawnAsteroidOnEdge() {
        while (true) {
            yield return new WaitForSeconds(4);
            spawner.SpawnAsteroidOnEdge(new AsteroidSpec(4, 4, 2, new AsteroidSpec(2, 8, 2, new AsteroidSpec(1, 10, 0, null))));
        }
    }

    void AddPoints(int value) {
        score += value;
        scoreValueTextInGame.text = score.ToString();
    }

    public int CalculateHighScore() {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
