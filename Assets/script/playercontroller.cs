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
    private Animator _animator;

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

        _animator.SetFloat("velocity", _rigidbody.linearVelocity.x);
        _animator.SetBool("isJumping", _rigidbody.linearVelocity.y != 0);
    }

    private void UpdateMovement()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x += -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += 1;
        }

        if (movement == Vector2.zero)
        {
            _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
        }
        else
        {
            //_rigidbody.position += movement * speed * Time.deltaTime;
            _rigidbody.linearVelocity += movement * speed * Time.deltaTime;
        }
    }

    private void UpdateJump()
    {
        if (jump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);


                slider.value -= 5;
            }
        }
        else if (can_double_jump == false) 
        {
           if (Input.GetKeyDown(KeyCode.Space) && doublejump == false)
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("ground")|| collision.gameObject.CompareTag("plateform")) &&_rigidbody.linearVelocity.y == 0)
        { jump = false; doublejump = false; _rigidbody.gravityScale = 1.73f; }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("plateform")) && _rigidbody.linearVelocity.y == 0)
        { jump = false; doublejump = false; _rigidbody.gravityScale = 1.73f; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("plateform"))
        { jump = true; }
    }
}
