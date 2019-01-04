using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float horizontalMove = 0f;
    float jumpSpeed = 3f;

    int score;

    bool grounded = false;
    bool doubleJump = true;
    bool isJumping = false;
    float yPos = 5f;
    float xPos = 0f;
    Rigidbody2D movementVector;
    Vector2 velocity = new Vector2(0,0);

	// Use this for initialization
	void Start () {
        movementVector = GetComponent<Rigidbody2D>();
	}

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded || doubleJump) {
                isJumping = true;
            } if (doubleJump) {
                doubleJump = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        velocity = movementVector.velocity;
        
        if (isJumping) {
            velocity.y = jumpSpeed;
            isJumping = false;
        }

        movementVector.velocity = new Vector2(velocity.x, velocity.y);

		/*if (Input.GetKeyDown(KeyCode.W))
        {
            jumpVector.velocity = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            jumpVector.velocity = new Vector2(xPos + 1, yPos);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            jumpVector.velocity = new Vector2(xPos - 1, yPos);
        }*/

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Floor") {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Floor") {
            grounded = false;
            doubleJump = true;
        }
    }
}
