using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int lives = 5;
    public int maxLives = 5;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.2f;
    public float canTakeDamageCounter;

    [Header("HealthBar")] 
    public Image[] leaves;

    private void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
    }

    private void Update()
    {
        PlayerPrefs.SetInt("Lives", lives);
        
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
        }

        for (int i = 0; i < leaves.Length; i++)
        {
            leaves[i].color = i < lives ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Spring"))
        {
            if (lives >= maxLives) return;
            lives += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (canTakeDamage && col.gameObject.CompareTag("Enemy"))
        {
            lives -= 1;
            if (lives <= 0)
            {
                // Reload Scene
            }
            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }
}
