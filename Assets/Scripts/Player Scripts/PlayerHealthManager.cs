using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int lives = 1;
    public int maxLives = 5;
    public bool isDown;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 2f;
    public float canTakeDamageCounter;

    public GameObject standingCol;
    public GameObject downCol;

    public AudioClip playerDamaged;
    public AudioClip playerHealed;

    [Header("HealthBar")] 
    public Image[] leaves;

    public GameObject tutorialKey;

    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;
    private AudioSource _as;

    private void Start()
    {
        isDown = false;
        lives = PlayerPrefs.GetInt("Lives");
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
        _as = GetComponent<AudioSource>();

        if (lives == 0)
        {
            Down();
        }
        else
        {
            Up();
        }
        
        if (SceneManager.GetActiveScene().name == "Tutorial_Level")
        {
            lives = 0;
        }
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

        if (SceneManager.GetActiveScene().name == "Tutorial_Level")
        {
            if (lives == 5)
            {
                tutorialKey.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Spring"))
        {
            if (lives >= maxLives) return;
            lives += 1;
            _as.PlayOneShot(playerHealed);
            Up();
        }
        if (canTakeDamage && other.gameObject.CompareTag("Enemy"))
        {
            lives -= 1;
            _as.PlayOneShot(playerDamaged);
            if (lives <= 0)
            {
                lives = 0;
                Down();
            }
            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }
    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (canTakeDamage && other.gameObject.CompareTag("Enemy"))
        {
            lives -= 1;
            _as.PlayOneShot(playerDamaged);
            if (lives <= 0)
            {
                lives = 0;
                Down();
            }
            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }*/

    private void Down()
    {
        isDown = true;
        _playerMovement.moveSpeed = 0.5f;
        //down animation
        _playerAttack.canAttack = false;
        canTakeDamage = false;
        downCol.gameObject.SetActive(true);
        standingCol.gameObject.SetActive(false);
    }

    private void Up()
    {
        isDown = false;
        standingCol.gameObject.SetActive(true);
        downCol.gameObject.SetActive(false);
        _playerAttack.canAttack = true;
        canTakeDamage = true;
        _playerMovement.moveSpeed = 2f;
    }
}
