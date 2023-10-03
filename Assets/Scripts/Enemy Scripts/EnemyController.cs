using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject player;
    public float speed;

    public int maxHealth = 3;
    public int currentHealth;

    private float distance;
    private KarmaManager _karma;

    private void Start()
    {
        currentHealth = maxHealth;
        _karma = GetComponent<KarmaManager>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //knockback

        if (currentHealth <= 0)
        {
            Die();
            _karma.karmaLevel -= 1;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}