using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 100f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            Debug.Log("GameOver");
            GameManager.instance.isGameOver = true;

            if (GameManager.instance.score > GameManager.instance.highscore)
                GameManager.instance.highscore = GameManager.instance.score;

            Time.timeScale = 0.0f;
            //raise OnGameEnd
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point"))
        {
            Debug.Log("+1");
            GameManager.instance.score++;
            GameManager.instance.scoreText.text = GameManager.instance.score.ToString();

            if (GameManager.instance.score > GameManager.instance.highscore)
                GameManager.instance.highscoreText.text = GameManager.instance.score.ToString();
        }
    }
}
