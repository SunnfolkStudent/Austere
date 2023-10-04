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
    private Animator _anim;
    private Rigidbody2D _rb;

    private void Start()
    {
        currentHealth = maxHealth;
        _karma = GetComponent<KarmaManager>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _anim.SetBool("isWalking", false);
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            _anim.SetBool("isWalking", true);
            if (_rb.velocity.y > 0)
            {
                _anim.SetBool("upWalk", true);
            }
            else
            {
                _anim.SetBool("upWalk", false);
            }
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