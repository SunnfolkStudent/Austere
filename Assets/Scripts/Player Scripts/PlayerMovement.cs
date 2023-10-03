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
                _anim.SetBool("isWalking", true);
                _anim.SetBool("sideWalk", true);
                _anim.SetBool("upWalk", false);
                _anim.SetBool("downWalk", false);
            }
            else
            {
                _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, 0f, groundFriction);
            }

            if (_input.moveDirection.y != 0f)
            {
                _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y,
                    moveSpeed * _input.moveDirection.y, accelerationTime);
                _anim.SetBool("isWalking", true);
                if (_rigidbody2D.velocity.y > 0.01f)
                {
                    _anim.SetBool("upWalk", true);
                    _anim.SetBool("sideWalk", false);
                }
                else
                {
                    _anim.SetBool("downWalk", true);
                    _anim.SetBool("sideWalk", false);
                }
            }
            else
            {
                _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y, 0f, groundFriction);
            }

            if (_input.moveDirection.x == 0f && _input.moveDirection.y == 0f)
            {
                _anim.SetBool("isWalking", false);
                _anim.SetBool("sideWalk", false);
                _anim.SetBool("downWalk", false);
                _anim.SetBool("upWalk", false);
            }

            _rigidbody2D.velocity = _desiredVelocity;
            transform.localScale = new Vector3(_input.moveDirection.x, 1, 1);
        }
    }
}

