using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ParticleSystem stars;
    private Vector2 offsetUp;
    private Vector2 offsetDown;
    private int direction;

    private void Start()
    {
        
    }

    private void Update()
    {
        offsetUp = new Vector2(transform.position.x, .2f);
        offsetDown = new Vector2(transform.position.x, -.2f);
        if (direction < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, offsetDown, .001f);
            if (Vector2.Distance(transform.position, offsetDown) < .05f)
                direction = 1;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, offsetUp, .001f);
            if (Vector2.Distance(transform.position, offsetUp) < .05f)
                direction = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        stars.Play();
        //Destroy(gameObject);
    }
}
