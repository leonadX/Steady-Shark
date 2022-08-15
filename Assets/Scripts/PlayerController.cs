using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;

    public float force = 100f;
    public Rigidbody2D rb;

    private void Awake()
    {
        player = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.instance.isGameOver)
        {
            Debug.Log("yes");
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && transform.position.y < 4.5f)
                {
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                }
            }

            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, transform.position.y - 0.5f, 4.5f));

            if (transform.position.y > 4.5f)
                rb.velocity = Vector3.zero;

            if (transform.position.y < -4.5f)
            {
                GameManager.instance.isGameOver = true;

                if (GameManager.instance.score > GameManager.instance.highscore)
                {
                    GameManager.instance.OnHighScore.Raise();
                    GameManager.instance.highscore = GameManager.instance.score;
                }
                else
                    GameManager.instance.OnGameOver.Raise();

                Time.timeScale = 0.0f;
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
            {
                GameManager.instance.OnHighScore.Raise();
                GameManager.instance.highscore = GameManager.instance.score;
            }
            else
                GameManager.instance.OnGameOver.Raise();

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
