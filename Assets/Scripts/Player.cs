using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 8f;
    private float JumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint; //Transform is any obj in the screen
    public float groundCheckRadius;
    public LayerMask groundLayer; //Things you will be able to jump from 
    private bool touchingGround;
    private bool playerFalling;
    private Animator playerAnimation;
    private Vector3 respawnPoint;

    private float playerScaleX;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        playerScaleX = GetComponent<Transform>().localScale.x;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        touchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);//Check if the player stands on an onj that he can jump

        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(playerScaleX, GetComponent<Transform>().localScale.y);
        }

        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-playerScaleX, GetComponent<Transform>().localScale.y);

        }
       
        if (Input.GetButtonDown("Jump") && touchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, JumpSpeed);
        }

        if (!touchingGround && rigidBody.velocity.y <= 0) // if the player is falling
        {
            playerFalling = true;
        }
        else
            playerFalling = false;

        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("TouchingGround", touchingGround);
        playerAnimation.SetBool("PlayerFalling", playerFalling);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")// what happens when a player falls down - respawning player
            transform.position = respawnPoint;
        if (other.tag == "Checkpoint")// what happens when a player finds a new checkpoint
            respawnPoint = other.transform.position;
    }
}
