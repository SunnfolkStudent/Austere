using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    
    public bool canAttack;
    
    public GameObject attackCircle;
    
    private InputManager _input;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        canAttack = true;
        attackCircle.gameObject.SetActive(false);
    }

    void Update()
    {
        
        if (_input.attackPressed)
        {
            Attack();
        }
        animator.SetFloat("LastMoveX", _input.moveDirection.x);
        animator.SetFloat("LastMoveY", _input.moveDirection.y);
    }

    private void Attack()
    {
        StartCoroutine(EnableAndDisable());
        animator.SetTrigger("Attack");

    }

    IEnumerator EnableAndDisable()
    {
        attackCircle.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.05f);
        attackCircle.gameObject.SetActive(false);
    }
}
