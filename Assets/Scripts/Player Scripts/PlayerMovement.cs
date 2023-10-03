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

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputManager>();
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
            }
            else
            {
                _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, 0f, groundFriction);
            }

            if (_input.moveDirection.y != 0f)
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
    }
}

