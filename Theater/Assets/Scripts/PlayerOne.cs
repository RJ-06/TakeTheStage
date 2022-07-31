using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpChange;
    [SerializeField] Rigidbody2D rb;

    private bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyUp(KeyCode.W) && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpChange);
        }
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //checks if you're touching the ground

        float moveInput = Input.GetAxisRaw("p1Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if ((facingRight == false && moveInput < 0) || (facingRight == true && moveInput > 0))
        {
            flip();
        }
    }


    void flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
