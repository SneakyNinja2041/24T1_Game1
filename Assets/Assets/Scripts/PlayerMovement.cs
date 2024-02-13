using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 15f;
    private float horizontal;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    public Rigidbody2D rb;
    Vector2 movement;

    public BoxCollider2D collisionBox;

    public bool isHaunting;

    

    private void Start()
    {
        isHaunting = false;
    }

    private void Update()
    {
        if(isHaunting == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
  
        if(isHaunting == true)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
        if (isHaunting == false)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        if (isHaunting == true)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetKeyDown("e"))
            {
                SwapState();
            }
        }
    }

    private void FixedUpdate()
    {



    }

    void SwapState()
    {        
            //detatch the child object from the player
            isHaunting = false;
            collisionBox.isTrigger = true;
            rb.gravityScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHaunting == false)
        {
            if (other.CompareTag("Haunt"))
            {
                Debug.Log("Collision with hauntable!");

                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Pressed Haunt Button!");
                    //set the collider objects position to the player's
                    //make the object a child of the player
                    isHaunting = true;
                    collisionBox.isTrigger = false;
                    rb.gravityScale = 2f;
                }

            }
        }
     
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

}
