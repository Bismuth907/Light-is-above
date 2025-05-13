using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class playercontroller : MonoBehaviour
{
    public Slider slider;
    private static bool getdoublejump = false;
    public static bool can_double_jump = true;
    public bool doublejump = false;
    public bool jump = false;
    public float speed = 5.0f;
    public float maxSpeed = 5.0f;
    public float maxjumpspeed = 5.0f;
    public float jumpForce = 5.0f;
    public float maxgravityscale = 8.0f;
    public float doublejumpForce = 5.0f;
    public float clampVelY;
    public float coyotetime = 0.2f;
    public float coyotetimecounter ;
    public bool isgrounded = false;

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
        if (isgrounded == true)
        {
            coyotetimecounter = coyotetime;
        }
        else
        {
            coyotetimecounter -= 0.1f;
        }
        UpdateMovement();
        UpdateJump();
        ClampVelocity();

        spriteRenderer.flipX = direction;

    }

    private void UpdateMovement()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            movement.x += -1;
            direction = true;
            _animator.SetBool("movit", true);
        }
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
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
        if(coyotetimecounter > 0f)
        {
            Debug.Log(coyotetimecounter + (" : Euh une huitre 🤓"));
            if (coyotetimecounter == coyotetime)
                Debug.Log("MARCHE");
            if (jump == false || jump == true && coyotetimecounter == coyotetime)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpForce);
                    _animator.SetBool("is jumping", true);

                    _animator.SetBool("Grounded", false);

                    slider.value -= 5;
                    Debug.Log(coyotetimecounter + (" : Hello :D"));

                }

            }
            
            
            else if (can_double_jump == false)
            {
                if (Input.GetKeyDown(KeyCode.Space) && doublejump == false)
                {
                    _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, doublejumpForce);
                    //_rigidbody.AddForce(new Vector2(_rigidbody.linearVelocity.x, doublejumpForce), ForceMode2D.Impulse);
                    _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, Mathf.Clamp(_rigidbody.linearVelocity.y, -100000, clampVelY));
                    _animator.SetBool("is jumping", false);
                    _animator.SetBool("is double jumping", true);

                    doublejump = true;
                    slider.value -= 5;
                }


            }

            }

            Vector2 velocity = _rigidbody.linearVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -maxjumpspeed, maxjumpspeed);
        _rigidbody.linearVelocity = velocity;

        if (velocity.y < 0)
            _rigidbody.gravityScale = 6;
        coyotetimecounter = 0f;
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
        {
            jump = false; doublejump = false; _rigidbody.gravityScale = 3f; isgrounded = true;
            _animator.SetBool("Grounded", true);
            _animator.SetBool("is jumping", false);
            _animator.SetBool("is double jumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("plateform"))
        { jump = true; }
        _animator.SetBool("Grounded", false);
        isgrounded = false;
    }
}