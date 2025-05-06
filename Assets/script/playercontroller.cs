using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class playercontroller : MonoBehaviour
{
    public Slider slider;
    private static bool getdoublejump = false;
    public static bool can_double_jump = true;
    private bool doublejump = false;
    private bool jump = false;
    public float speed = 5.0f;
    public float maxSpeed = 5.0f;
    public float maxjumpspeed = 5.0f;
    public float jumpForce = 5.0f;
    public float maxgravityscale = 6.0f;

    private Rigidbody2D _rigidbody;
    public Animator _animator;
    public SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private bool direction;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateJump();
        ClampVelocity();

        spriteRenderer.flipX = direction;

        _animator.SetFloat("velocity", _rigidbody.linearVelocity.x);
        _animator.SetBool("isJumping", _rigidbody.linearVelocity.y != 0);
    }

    private void UpdateMovement()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x += -1;
            direction = true;
            _animator.SetBool("movit", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += 1;
            direction = false;
            _animator.SetBool("movit", true);
        }

        if (movement == Vector2.zero)
        {
            _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
            _animator.SetBool("movit", false);
        }
        else
        {
            //_rigidbody.position += movement * speed * Time.deltaTime;
            _rigidbody.linearVelocity += movement * speed * Time.deltaTime;
        }
        _animator.SetBool("falling", _rigidbody.linearVelocity.y  < 0);
        _animator.SetBool("canDJ", !doublejump);
    }

    private void UpdateJump()
    {
        if (jump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _animator.SetBool("is jumping", true);
                
                _animator.SetBool("Grounded", false);

                slider.value -= 5;
            }
        }
        else if (can_double_jump == false) 
        {
           if (Input.GetKeyDown(KeyCode.Space) && doublejump == false)
            {
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpForce);
                 _animator.SetBool("is jumping", false);
                _animator.SetBool("is double jumping", true);
                
                doublejump = true;
                slider.value -= 5;
            }

            Vector2 velocity = _rigidbody.linearVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -maxjumpspeed, maxjumpspeed);
            _rigidbody.linearVelocity = velocity;

            if (velocity.y < 0)
                _rigidbody.gravityScale = 3; 
        }
    }

    private void ClampVelocity()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        _rigidbody.linearVelocity = velocity;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("plateform")) && _rigidbody.linearVelocity.y == 0)
        { jump = false; doublejump = false; _rigidbody.gravityScale = 1.73f;
            _animator.SetBool("Grounded", true);
            _animator.SetBool("is jumping", false);
            _animator.SetBool("is double jumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("plateform"))
        { jump = true; }
    }
}
