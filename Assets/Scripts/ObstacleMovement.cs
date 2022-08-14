using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 3f;

    private void Update()
    {
        if (transform.position.x < -6)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
