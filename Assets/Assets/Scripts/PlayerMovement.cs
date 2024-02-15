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
    public TrailRenderer trail;
    public SpriteRenderer playerSprite;

    public bool isHaunting;
    public bool isOverHaunt;

    public GameObject itemToGrab;
    public GameObject itemHold;

    Key keyColour;
    Block blockColour;

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

            if (isOverHaunt == true && Input.GetKeyDown(KeyCode.Q))
            {

                SwapState2();
            }

        }
  
        if(isHaunting == true)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            trail.enabled = false;
            playerSprite.color = new Color(1, 1, 1, 0.15f);
        }
        if (isHaunting == false)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            trail.enabled = true;
            playerSprite.color = new Color(1, 1, 1, 1);
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
        itemToGrab.GetComponent<Rigidbody2D>().simulated = true;
        itemToGrab.transform.parent = null;
        // Audio for detach

        isHaunting = false;
        collisionBox.isTrigger = true;
        rb.gravityScale = 0f;
    }

    void SwapState2()
    {
        itemToGrab.GetComponent<Rigidbody2D>().simulated = false;
        itemToGrab.transform.position = itemHold.transform.position;
        itemToGrab.transform.parent = itemHold.transform;

        if(itemToGrab.tag == "Haunt")
        {
            itemToGrab.GetComponent<Block>().Colour();
            
        }
        if(itemToGrab.tag == "Key")
        {
            itemToGrab.GetComponent<Key>().Colour();
            
        }

        isHaunting = true;
        collisionBox.isTrigger = false;
        rb.gravityScale = 2f;
        Debug.Log("Pressed Haunt Button!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            isOverHaunt = true;
            itemToGrab = other.gameObject;
        }
        
        if (other.CompareTag("Haunt"))
        {
            Debug.Log("Collision with hauntable!");
            isOverHaunt = true;
            itemToGrab = other.gameObject;
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Haunt"))
        {
            isOverHaunt = false;  
        }
        if (other.CompareTag("Key"))
        {
            isOverHaunt = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

}
