using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDeath : MonoBehaviour
{
    private float time = 2f;
    public ParticleSystem death;

    private void Awake()
    {
        ParticleSystem particleObject = Instantiate(death, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (time <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
