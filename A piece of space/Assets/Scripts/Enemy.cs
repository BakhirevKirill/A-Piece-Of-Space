using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float r;
    public static float x_speed = 0.5f;
    protected float y_speed = 0.05f; 
    
    
    private void Start()
    {
        float rand = Random.Range(-y_speed, y_speed);
        r = rand;
    }

    
    void FixedUpdate()
    {
        if (MenuScript.OnPause == false)
        {
            Vector2 position = transform.position;
            position.x -= x_speed;
            position.y += r;
            transform.position = position;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreCounter score = other.GetComponent<ScoreCounter>();
        Main player = other.GetComponent<Main>();

        if (score != null)
        {
            score.ScoreCount();
            Destroy(gameObject);
        }

        if (player != null)
        {
            player.Damage();
            Destroy(gameObject);
        }
    }
}
