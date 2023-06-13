using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float r;
    public static float x_speed = 0.8f;
    public float y_speed = 0.05f;
    
    
    private void Start()
    {
        float rand = Random.Range(-y_speed, y_speed);
        r = rand;
    }

    
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x -= x_speed;
        position.y += r;
        transform.position = position;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Main player = other.GetComponent<Main>();
        ScoreCounter score = other.GetComponent<ScoreCounter>();
        
        if (score != null)
        {
            score.ScoreCount();
            Destroy(gameObject);
        }

        if (player != null)
        {
            player.Fire();
            Destroy(gameObject);
        }
    }
}
