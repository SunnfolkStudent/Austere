using System;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    //I recommend 7 for the move speed, and 1.2 for the force damping
    private Rigidbody2D _rigidbody2D;
    public float moveSpeed;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;
    
    [Header("Acceleration")]
    public float accelerationTime = 0.02f;
    public float groundFriction = 0.03f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        _rigidbody2D.velocity = moveForce;
        
        if (PlayerInput.x != 0)
        {
            PlayerInput.x = Mathf.Lerp( _rigidbody2D.velocity.x,PlayerInput.x * moveSpeed, accelerationTime);
        }
        else
        {
            PlayerInput.x = Mathf.Lerp(PlayerInput.x, 0f, groundFriction);
        }
        
        if (PlayerInput.y != 0)
        {
            PlayerInput.y = Mathf.Lerp(_rigidbody2D.velocity.y, PlayerInput.y * moveSpeed, accelerationTime);
        }
        else
        {
            PlayerInput.x = Mathf.Lerp(PlayerInput.x, 0f, groundFriction);
        }
        
    }
 
    
}



/*{


    private void FixedUpdate()
    {
        if (_input.moveDirection.x != 0)
        {
            _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, 
                moveSpeed * _input.moveDirection.x, accelerationTime);
        }
        else
        {
            _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, 0f, groundFriction);
        }
        
        if (_input.moveDirection.y != 0)
        {
            _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y, 
                moveSpeed * _input.moveDirection.y, accelerationTime);
        }
        else
        {
            _desiredVelocity.y = Mathf.Lerp(_desiredVelocity.y, 0f, groundFriction);
        }

        Vector2 moveForce = _input.moveDirection * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }

        _rigidbody2D.velocity = moveForce;
        
        

        _rigidbody2D.velocity = _desiredVelocity;
    }
}*/

