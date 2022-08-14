using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver;
    private bool hasGameStarted;
    public GameObject obstacles;
    public int score;
    public int highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        instance = this;
        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = "Best = " + highscore.ToString();
        hasGameStarted = false;
        Time.timeScale = 0.0f;
    }

    void Start()
    {
        scoreText.text = score.ToString();
        /*isGameOver = false;
        StartCoroutine(SpawnObstacles());*/
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasGameStarted && Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Time.timeScale = 1.0f;
                isGameOver = false;
                hasGameStarted = true;
                StartCoroutine(SpawnObstacles());
            }
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (!isGameOver) {
            yield return new WaitForSeconds(2);
            Vector2 spawnPos = new Vector2(8f, Random.Range(-1.5f, 2.2f));
            Instantiate(obstacles, spawnPos, obstacles.transform.rotation);
        }
    }
}
