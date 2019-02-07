using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCharacter : MonoBehaviour {

    private Vector2 velocity;
    private float gravityScale;

	public void Pause() {
        velocity = GetComponent<Rigidbody2D>().velocity;
        gravityScale = GetComponent<Rigidbody2D>().gravityScale;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<PlayerController>().paused = true;

    }

    public void Unpause() {
        GetComponent<Rigidbody2D>().velocity = velocity;
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        GetComponent<PlayerController>().paused = false;
    }
}
