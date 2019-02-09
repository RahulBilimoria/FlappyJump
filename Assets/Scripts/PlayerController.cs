using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

    public CharacterData data;

    //change to public later
    float movementSpeed = 5f;
    float jumpSpeed = 6f;
    float fallModifier = 1.5f;

    //upgrade modifiers
    float movementSpeedMultiplier;
    float maxMovementSpeedMultiplier;
    float jumpSpeedMultiplier;
    float horizontalMove = 0f;
    float lastY;
    float height;

    bool canJump = false;
    bool doubleJump = true;
    bool isJumping = false;
    public bool paused = false;

    int points;
    int currency;
    int life;

    public GameObject gameOverScreen;
    public GameObject gameUIScreen;

    public GameObject[] hitpoints = new GameObject[3];
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI[] pauseText = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] gameOverText = new TextMeshProUGUI[6];
    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        points = 0;
        height = 0;
        life = 3;
        lastY = transform.position.y;
    }

    void Update() {
        if (rb.velocity.y > 0) {
            GetComponent<CircleCollider2D>().isTrigger = true;
            height += transform.position.y - lastY;
            heightText.text = "Height: " + (int)height + "m";
        } else {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
        lastY = transform.position.y;
        //gets left & right input
        if (!paused) {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            //gets jump imput
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (canJump || doubleJump) {
                    isJumping = true;
                }
                if (doubleJump) {
                    doubleJump = false;
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        //changes gravity to make player fall faster
        if (!paused) {
            if (rb.velocity.y < 0) {
                rb.gravityScale = fallModifier;
            } else {
                rb.gravityScale = 1f;
            }
        }

        //adds force for jumping
        if (isJumping) {
            // if player is falling, adds a force equal to its falling speed to simulate a jump in mid air
            Vector2 jumpForce = rb.velocity.y < 0 ? Vector2.up * (rb.velocity.y * -1 + (jumpSpeed + jumpSpeed * data.jumpHeightModifier)) : Vector2.up * jumpSpeed;
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }

        //adds force for left and right movement
        if (horizontalMove < 0) {
            // if player changes directions, adds a force to "cancel" out its current velocity
            if (rb.velocity.x > 0) rb.AddForce((rb.velocity.x * 0.25f) * Vector2.right * -1, ForceMode2D.Impulse);

            rb.AddForce(Vector2.right * -1 * movementSpeed, ForceMode2D.Force);
        } else if (horizontalMove > 0) {
            // if player changes directions, adds a force to "cancel" out its current velocity
            if (rb.velocity.x < 0) rb.AddForce((rb.velocity.x * 0.25f) * Vector2.right * -1, ForceMode2D.Impulse);

            rb.AddForce(Vector2.right * movementSpeed, ForceMode2D.Force);
        } else if (horizontalMove == 0 && rb.velocity.x != 0) {
            // if there is no input, adds a force to gradually slow down the player
            rb.AddForce(rb.velocity.x * Vector2.right * -0.05f, ForceMode2D.Impulse);
        }

	}

    public void Jump() {
        isJumping = true;
        doubleJump = false;
    }

    public void UpdatePauseStats() {
        pauseText[0].text = "Current Height: " + (int)height + "m";
        pauseText[1].text = "Points Gained: " + points + "pts";
        pauseText[2].text = "Your Gems: " + currency + " Gems";
    }

    private void GameOver() {
        data.currency += currency;
        if (height > data.bestHeight) {
            data.bestHeight = height;
        }
        if (points > data.bestScore) {
            data.bestScore = points;
        }
        //user score
        gameOverText[0].text = "Height: " + (int)height + "m";
        gameOverText[1].text = "Score: " + points + "pts";
        //user personal best
        gameOverText[2].text = "Height: " + (int)data.bestHeight + "m";
        gameOverText[3].text = "Score: " + data.bestScore + "pts";
        gameOverText[4].text = currency + " Gems Gained";
        gameOverText[5].text = "Total Gems: " + data.currency;
        //end spawners?
        GlobalSettings.speed = 0.0f;
        rb.isKinematic = true;
        //Disable current UI when game ends or overlay game over screen on top of it
        //show game over screen, enable all gameover screens, disable all ingame spawners etc.
        //maybe some death animations
        gameUIScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        SaveData.SaveGameData(data);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor") && collision.gameObject.tag == "Spawnable") {
            canJump = true;
            points += (int)Mathf.Ceil(collision.gameObject.GetComponent<Platform>().collectPoints() * data.pointsMultiplier);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Collectible")) {
            currency += collision.gameObject.GetComponent<Collectible>().getValue() + data.gemValueMultiplier;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
            //if can kill, end game
            //if cant kill, subtract points / currency or apply debuff or something
            collision.gameObject.SetActive(false);
            life--;
            hitpoints[life].SetActive(false);
            if (life <= 0) {
                GameOver();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor") && collision.gameObject.tag == "Spawnable") {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (!GlobalSettings.gameStarted) {
            data = GlobalSettings.characterData;
            GlobalSettings.gameStarted = true;
            GlobalSettings.speed = 1.0f;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor")) {
            canJump = false;
            doubleJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Finish" && GlobalSettings.gameStarted) {
            GlobalSettings.gameStarted = false;
            GameOver();
        }
    }
}
