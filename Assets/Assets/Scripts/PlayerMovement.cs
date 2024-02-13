using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    private float horizontal;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    public Rigidbody2D rb;
    Vector2 movement;

    public BoxCollider2D collisionBox;

    public bool isHaunting;
    public bool isOverHaunt;

    public Transform itemToHaunt;
    public GameObject itemToGrab;

    private void Start()
    {
        isHaunting = false;
        isOverHaunt = false;
    }

    private void Update()
    {
        if(isHaunting == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (isOverHaunt == true && Input.GetKeyDown("e"))
            {
                SwapState2();
            }

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
                SwapState1();
            }
        }
    }


    void SwapState1()
    {        
            //detatch the child object from the player
            isHaunting = false;
            collisionBox.isTrigger = true;
            rb.gravityScale = 0f;
    }

    void SwapState2()
    {
        Debug.Log("Pressed Haunt Button!");
        //set the collider objects position to the player's
        //make the object a child of the player
        isHaunting = true;
        collisionBox.isTrigger = false;
        rb.gravityScale = 2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
            if (other.CompareTag("Haunt"))
            {
                Debug.Log("Collision with hauntable!");
                isOverHaunt = true;
            }
            else
            {
                isOverHaunt = false;
            }
        
     
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

}
