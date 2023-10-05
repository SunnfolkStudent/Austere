using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    private Vector2 _desiredVelocity;
    
    [Header("Acceleration")]
    public float accelerationTime = 0.2f;
    public float groundFriction = 0.15f;

    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private InputManager _input;
    private Animator _anim;
    private SpriteRenderer _sr;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputManager>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _desiredVelocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = _desiredVelocity;

        if (_input.moveDirection.x != 0)
        {
            transform.localScale = new Vector3(_input.moveDirection.x, 1, 1);
        }
    }
    
    private void FixedUpdate()
    {
        if (InputDialogueManager.playerControlsDisabled == false || DialogueManager.PlayerControlsDisabled == false)
        {
            if (_input.moveDirection.magnitude > 1)
            {
                _input.moveDirection.Normalize();
            }

            if (_input.moveDirection != Vector2.zero)
            {
                _anim.Play("Player_Walk");
                _anim.SetFloat("X", _input.moveDirection.x);
                _anim.SetFloat("Y", _input.moveDirection.y);
            }
            else
            {
                _anim.Play("Player_Idle"); 
            }
            
            // direction = animation
            if (_input.moveDirection.x != 0)
            {
                _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x,
                    moveSpeed * _input.moveDirection.x, accelerationTime);
            }
            else
            {
                _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, 0f, groundFriction);
            }
            
            if(_input.moveDirection.y != 0)
            {
                _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y,
                    moveSpeed * _input.moveDirection.y, accelerationTime);
            }
            else
            {
                _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y, 0f, groundFriction);
            }
            

            _rigidbody2D.velocity = _desiredVelocity;
        }
        if (InputDialogueManager.playerControlsDisabled == true || DialogueManager.PlayerControlsDisabled == true || BossDialogueManager.PlayerControlsDisabled == true)
        { 
            
            _rigidbody2D.velocity = Vector3.zero;
            _anim.Play("Player_Idle");
        }
    }
}

