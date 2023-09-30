using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int lives = 5;
    public int maxLives = 5;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.2f;
    public float canTakeDamageCounter;

    private void Update()
    {
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
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
