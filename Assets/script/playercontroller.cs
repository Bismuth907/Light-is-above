using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerCharacter2D : MonoBehaviour
{
    private static bool getdoublejump = false;
    private bool doublejump = false;
    private bool jump = false;
    public float speed = 5.0f;
    public float maxSpeed = 5.0f;
    public float jumpForce = 5.0f;

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
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doublejump == false)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            doublejump = true;
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
        if(collision.gameObject.CompareTag("ground")&&_rigidbody.linearVelocity.y == 0)
        { jump = false; doublejump = false; }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && _rigidbody.linearVelocity.y == 0)
        { jump = false; doublejump = false; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        { jump = true; }
    }
}
