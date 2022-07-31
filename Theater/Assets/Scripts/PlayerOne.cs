using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    //movement
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpChange;
    [SerializeField] Rigidbody2D rb;
    private bool facingRight = true;

    //groundcheck
    private bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    //attack and combat
    public GameObject sword;
    public int health = 100;
    [SerializeField] int damage;
    [SerializeField] Transform swordPos;
    private float attackWaitTime = .8f;

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

        if (Input.GetKeyDown(KeyCode.V) && attackWaitTime < 0) {
            attack();
        }
        attackWaitTime -= Time.deltaTime;
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //checks if you're touching the ground

        float moveInput = Input.GetAxisRaw("p1Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if ((facingRight == false && moveInput > 0) || (facingRight == true && moveInput < 0))
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

    void attack() {
        GameObject tempSword = Instantiate(sword,swordPos);
        Destroy(tempSword, .5f);
        attackWaitTime = .8f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("p2Sword")) {
            health -= damage;   
        }
    }
}
