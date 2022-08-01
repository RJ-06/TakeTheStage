using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
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
    [SerializeField] float attackWaitTime = .45f;
    public bool guarding;

    [SerializeField] float healTime;
    private float healTimer = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpChange);
        }

        if (Input.GetKeyDown(KeyCode.Period) && attackWaitTime < 0 && !guarding)
        {
            attack();
        }
        attackWaitTime -= Time.deltaTime;


        guarding = Input.GetKey(KeyCode.DownArrow) && isGrounded;
        healTimer += Time.deltaTime;
        if (healTimer > healTime && health < 100)
        {
            health++;
        }

    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //checks if you're touching the ground

        float moveInput = Input.GetAxisRaw("p2Horizontal");

        if (!guarding)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


        if ((facingRight == false && moveInput > 0) || (facingRight == true && moveInput < 0))
        {
            flip();
        }

    }


    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void attack()
    {
        GameObject tempSword = Instantiate(sword, swordPos);
        Destroy(tempSword, .3f);
        attackWaitTime = .45f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("p1Sword") && !guarding)
        {
            health -= damage;
            healTimer = 0;
        }
    }
}
