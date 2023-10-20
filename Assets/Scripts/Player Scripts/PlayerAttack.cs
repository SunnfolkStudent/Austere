using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    
    public GameObject attackCircle;
    
    private InputManager _input;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        attackCircle.gameObject.SetActive(false);
    }

    void Update()
    {
        
        if (_input.attackPressed)
        {
            Attack();
        }
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
