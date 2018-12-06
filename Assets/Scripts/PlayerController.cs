using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    int score;
    bool grounded;
    float yPos = 5f;
    float xPos = 0f;
    Rigidbody2D jumpVector;

	// Use this for initialization
	void Start () {
        jumpVector = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.W))
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
        }

	}
}
