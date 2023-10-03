using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private InputManager _input;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<InputManager>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (_input.moveDirection.x != 0)
        {
            _animator.Play("Player_SideWalk");
        }else if (_input.moveDirection.y > 0)
        {
            _animator.Play("Player_UpWalk");
        }else if (_input.moveDirection.y < 0)
        {
            _animator.Play("Player_DownWalk");
        }
        else
        {
            _animator.Play("Player_Idle");
        }

        if (_input.moveDirection.x == 0 || _input.moveDirection.y == 0) return;
        var transform1 = transform;
        transform1.localScale = new Vector3(_input.moveDirection.x, 1, 1);
    }
}
