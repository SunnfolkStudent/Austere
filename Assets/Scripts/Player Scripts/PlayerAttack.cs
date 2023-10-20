using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool canAttack;
    
    public GameObject attackCircle;
    
    private InputManager _input;
    private Animator _animator;

    public float attackTimeCounter;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _animator = GetComponent<Animator>();
        attackCircle.gameObject.SetActive(false);
    }

    void Update()
    {
        if (InputDialogueManager.playerControlsDisabled == false || DialogueManager.PlayerControlsDisabled == false ||
            BossDialogueManager.PlayerControlsDisabled == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        if (_input.attackPressed && canAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        StartCoroutine(EnableAndDisable());
        //_animator.SetTrigger("Attack");
        _animator.Play("Attack");
        attackTimeCounter = Time.time + 0.2f;

    }

    IEnumerator EnableAndDisable()
    {
        attackCircle.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.05f);
        attackCircle.gameObject.SetActive(false);
    }
}
