using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;

    private bool isGrounded;
    private bool secondJump;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        if (isGrounded == true)
        {
            rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * speed * Time.deltaTime * 0.75f, rb.velocity.y);
        }

  
        if(moveInput < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
        else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded == false && secondJump == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            secondJump = false ;
        }
        else if(isGrounded == true)
        {
            secondJump = true;
        }
    }
}
