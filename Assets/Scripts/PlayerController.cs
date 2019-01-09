using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //change to public later
    float movementSpeed = 5f;
    float maxMovementSpeed = 3f;
    float jumpSpeed = 6f;
    float fallModifier = 2.5f;
    float maxFallSpeed = 5f;

    float horizontalMove = 0f;

    bool canJump = false;
    bool doubleJump = true;
    bool isJumping = false;
    
    Rigidbody2D rb;
    Vector2 velocity = new Vector2(0,0);

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

        //gets left & right input
        horizontalMove = Input.GetAxisRaw("Horizontal");

        //gets jump imput
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canJump || doubleJump) {
                isJumping = true;
            } if (doubleJump) {
                doubleJump = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //changes gravity to make player fall faster
        if (rb.velocity.y < 0) {
            rb.gravityScale = fallModifier;
        } else {
            rb.gravityScale = 1f;
        }

        //adds force for jumping
        if (isJumping) {
            // if player is falling, adds a force equal to its falling speed to simulate a jump in mid air
            Vector2 jumpForce = rb.velocity.y < 0 ? Vector2.up * (rb.velocity.y * -1 + jumpSpeed) : Vector2.up * jumpSpeed;

            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }

        //adds force for left and right movement
        if (horizontalMove < 0) {
            // if player changes directions, adds a force to "cancel" out its current velocity
            if (rb.velocity.x > 0) rb.AddForce(rb.velocity.x * Vector2.right * -1, ForceMode2D.Impulse);

            rb.AddForce(Vector2.right * -1 * movementSpeed, ForceMode2D.Force);
        } else if (horizontalMove > 0) {
            // if player changes directions, adds a force to "cancel" out its current velocity
            if (rb.velocity.x < 0) rb.AddForce(rb.velocity.x * Vector2.right * -1, ForceMode2D.Impulse);

            rb.AddForce(Vector2.right * movementSpeed, ForceMode2D.Force);
        } else if (horizontalMove == 0 && rb.velocity.x != 0) {
            // if there is no input, adds a force to gradually slow down the player
            rb.AddForce(rb.velocity.x * Vector2.right * -0.05f, ForceMode2D.Impulse);
        }

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Floor") {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Floor") {
            canJump = false;
            doubleJump = true;
        }
    }
}
