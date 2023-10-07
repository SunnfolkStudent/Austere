using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.25f;
    public float attackDistance = 2;

    public int maxHealth = 3;
    public int currentHealth;
    public GameObject key;

    public AudioClip keyDrop;
    public AudioClip enemyGrowl;

    private bool canTakeDamage;
    private float canTakeDamageTime = 1f;
    private float canTakeDamageCounter;

    private Color original;

    private float distance;
    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private AudioSource _as;

    private void Start()
    {
        currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _as = GetComponent<AudioSource>();
        key.gameObject.SetActive(false);
        original = _sr.color;
    }

    private void Update()
    {
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
        }
        _anim.SetBool("isWalking", false);
        _rb.velocity = Vector3.zero;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (distance < attackDistance)
            {
                _as.PlayOneShot(enemyGrowl);
                EnemyMove();
            }
    }

    public void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        _anim.SetBool("isWalking", true);
        //flip when turned
        //transform.localScale = new Vector3(_rb.velocity.x, 1, 1);
        _sr.transform.localScale = new Vector2(_rb.velocity.x > 0 ? 1 : -1, 1);
            
        if (_rb.velocity.y > 0)
        {
            _anim.SetBool("upWalk", true);
            Debug.Log("Enemy UP");
        }
        else
        {
            _anim.SetBool("upWalk", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackCircle") && canTakeDamage)
        {
            TakeDamage();
            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }

    public void TakeDamage()
    {
        StartCoroutine(hurtFlash());
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            KarmaManager.instance.AddSmallKarma();
            Die();
        }
    }

    void Die()
    {
        key.gameObject.SetActive(true);
        _as.PlayOneShot(keyDrop);
        Destroy(gameObject);
    }

    IEnumerator hurtFlash()
    {
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sr.color = original;
    }
}