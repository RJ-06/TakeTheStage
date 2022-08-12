using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    //movement
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpChange;
    public Rigidbody2D rb;
    private bool facingRight = true;

    //groundcheck
    private bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    //attack and combat
    public GameObject sword;
    public static int health = 100;
    [SerializeField] Transform swordPos;
    [SerializeField] float attackWaitTime = .4f;
    public bool guarding;
    [SerializeField] GameObject shield;

    public Animator animator;

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
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpChange);
        }

        if (Input.GetKeyDown(KeyCode.V) && attackWaitTime < 0 && !guarding) {
            attack();
        }
        attackWaitTime -= Time.deltaTime;
        

        guarding = Input.GetKey(KeyCode.S) && isGrounded;

        shield.SetActive(guarding);

        if (health < 0)
            health = 0;
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //checks if you're touching the ground

        float moveInput = Input.GetAxisRaw("p1Horizontal");

        animator.SetFloat("speed",Mathf.Abs(moveInput));
        animator.SetBool("isJumping", !isGrounded);

        if (!guarding)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        else {
            rb.velocity = Vector2.zero;
        }


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
        Destroy(tempSword, .2f);
        attackWaitTime = .4f;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "p2Sword" && !guarding)
        {
            health -= 10;
            ExcitementBar.excitementVal += 4;

            if (rb.velocity.y < -7) {
                ExcitementBar.excitementVal += 15;
            }

            rb.AddForce(new Vector2(4500 * Mathf.Sign(this.transform.position.x - col.transform.position.x), 350));
        }

        
    }

}
