using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public bool canAttack;
    public bool isAttacking;
    public GameObject attackCircle;
    
    private InputManager _input;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        canAttack = true;
        isAttacking = false;
        attackCircle.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_input.attackPressed && canAttack == true)
        {
            Attack();
        }
    }

    private void Attack()
    {
        isAttacking = true;
        StartCoroutine(EnableAndDisable());
        //play attack animation
        //animator.SetTrigger("Attack")

    }

    IEnumerator EnableAndDisable()
    {
        attackCircle.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.05f);
        this.attackCircle.gameObject.SetActive(false);
        isAttacking = false;
    }
}
