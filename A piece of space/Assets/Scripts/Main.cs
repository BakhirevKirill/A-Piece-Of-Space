using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class Main : MonoBehaviour
{
    static public int s_health = 10;
    public TMP_Text health_count;
    public TMP_Text bestScore;
    public GameObject partOfDeath;
    private float f_timer = 10f;
    public static bool onFire = false;
    public GameObject looseMenu;
    private int best;
    public AudioClip audioHit;
    private AudioSource audioSource;
    public AudioSource exp;
    public AudioSource newBest;
    public AudioClip powerUp;
    public Transform target;
    private Rigidbody2D rb;
    static public int a = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Best Score"))
        {
            best = PlayerPrefs.GetInt("Best Score");
            if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
            {
                bestScore.text = "Best Score\n" + best.ToString();
            }
            else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
            {
                bestScore.text = "Рекорд\n" + best.ToString();
            }
        }
    }
    
    
    void FixedUpdate()
    {
        if (a == 1)
        {
            rb.AddForce( (target.transform.position - transform.position).normalized * 40);
        }
        else if (a == 0)
        {
            rb.velocity = Vector3.zero;
            
        }

        if (Input.touchCount > 0) Swipe();
        
        if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
        {
            health_count.text = "HP: " + s_health.ToString();
        }
        else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
        {
            health_count.text = "Жизни: " + s_health.ToString();
        }
        
        if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
        {
            bestScore.text = "Best Score\n" + best.ToString();
        }
        else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
        {
            bestScore.text = "Рекорд\n" + best.ToString();
        }
        
        if (s_health <= 0)
        {
            if (ScoreCounter.score > best)
            {
                if (PlayerPrefs.GetInt("sounds") == 1) {newBest.Play();}
                best = ScoreCounter.score;
                
                if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
                {
                    bestScore.text = "Best Score\n" + best.ToString();
                }
                else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
                {
                    bestScore.text = "Рекорд\n" + best.ToString();
                }
                
                PlayerPrefs.SetInt("Best Score", best);
                PlayerPrefs.Save();
            }
            if (PlayerPrefs.GetInt("sounds") == 1) {exp.Play();}
            Instantiate(partOfDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            looseMenu.SetActive(true);
        }

        if (onFire == true)
        {
            f_timer -= Time.deltaTime;
            if (f_timer <= 0) onFire = false;
        }
        else
        {
            ParticleSystem stars = GameObject.Find("Stars").GetComponent<ParticleSystem>();
            f_timer = 10f;
            stars.startSpeed = 20f;
            Enemy.x_speed = 0.8f;
            Health.x_speed = 0.8f;
            HoleGravity.x_speed = 0.2f;
            ParticleSystem tail = GameObject.Find("Tail").GetComponent<ParticleSystem>();
            tail.enableEmission = false;
        }
    }

    
    void Swipe()
    {
        Vector2 delta = Input.GetTouch(0).deltaPosition;
        Vector3 position = transform.position;
        if (MenuScript.OnPause == false)
        {
            if ((position.y < 16) && (position.y > -16))
            {
                position.y += 0.04f * delta.y;
            }
            else
            {
                if (position.y > 16)
                {
                    position.y -= 1;
                    transform.position = position;
                }

                if (position.y < -16)
                {
                    position.y += 1;
                    transform.position = position;
                }
            }
        
            if ((position.x < 34) && (position.x > -34))
            {
                position.x += 0.04f * delta.x;
            }
            else
            {
                if (position.x > 34)
                {
                    position.x -= 1;
                    transform.position = position;
                }

                if (position.x < -34)
                {
                    position.x += 1;
                    transform.position = position;
                }
            }
            transform.position = position;
        }
    }

    
    public void Damage()
    {
        if (onFire == false)
        {
            s_health -= 1;
            if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(audioHit);}
        }
        else
        {
            ScoreCounter.score++;
        }
    }
    
    public void BlackDamage()
    {
        if (onFire == false)
        {
            s_health -= 3;
            if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(audioHit);}
        }
        else
        {
            ScoreCounter.score += 30;
        }
    }

    
    public void HealthUp()
    {
        audioSource.PlayOneShot(powerUp);
        if (s_health < 10) s_health += 1;
    }
    
    
    public void Fire()
    {
        audioSource.PlayOneShot(powerUp);
        ParticleSystem stars = GameObject.Find("Stars").GetComponent<ParticleSystem>();
        ParticleSystem tail = GameObject.Find("Tail").GetComponent<ParticleSystem>();
        tail.enableEmission = true;
        onFire = true;
        stars.startSpeed = 100f;
        Enemy.x_speed = 5f;
        Health.x_speed = 5f;
        HoleGravity.x_speed = 2f;
    }
}
