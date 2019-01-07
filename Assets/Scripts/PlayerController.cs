using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float fallModifier = 2.5f;
    public float jumpSpeed = 3f;

    float horizontalMove = 0f;

    float yPos = 5f;
    float xPos = 0f;

    int score;

    bool grounded = false;
    bool doubleJump = true;
    bool isJumping = false;
    
    Rigidbody2D rb;
    Vector2 velocity = new Vector2(0,0);

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        //movementVector = GetComponent<Rigidbody2D>();
	}

    void Update() {

        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallModifier - 1) * Time.deltaTime;
        }

        //horizontalMove = Input.GetAxisRaw("Horizontal");
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
        //Vector2 move = Vector2.zero;
        //move.x = Input.GetAxis("Horizontal");
        
        if (isJumping) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = false;
        }

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
