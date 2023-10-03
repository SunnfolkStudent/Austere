using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Vector2 _desiredVelocity;
    
    [Header("Acceleration")]
    public float accelerationTime = 0.02f;
    public float groundFriction = 0.03f;

    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private InputManager _input;
    private Animator _anim;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputManager>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _desiredVelocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = _desiredVelocity;
    }
    
    private void FixedUpdate()
    {
        if (InputDialogueManager.playerControlsDisabled == false)
        {


            if (_input.moveDirection.magnitude > 1)
            {
                _input.moveDirection.Normalize();
            }

            if (_input.moveDirection.x != 0)
            {
                _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x,
                    moveSpeed * _input.moveDirection.x, accelerationTime);
                _anim.Play("Player_SideWalk");
                
                if (_rigidbody2D.velocity.x < 0.01f)
                {
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, 0f, groundFriction);
            }

            if (_input.moveDirection.y != 0f)
            {
                _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y,
                    moveSpeed * _input.moveDirection.y, accelerationTime);
                if (_rigidbody2D.velocity.y > 0.01f)
                {
                    _anim.Play("Player_UpWalk");
                }
                else
                {
                    _anim.Play("Player_DownWalk");
                }
            }
            else
            {
                _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y, 0f, groundFriction);
            }

            if (_input.moveDirection.x == 0f && _input.moveDirection.y == 0f)
            {
                _anim.Play("Player_Idle");
            }

            _rigidbody2D.velocity = _desiredVelocity;
        }
    }
}

