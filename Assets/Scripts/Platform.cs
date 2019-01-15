using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public GameObject player;

    private bool pointsCollected = false;
    public int points = 100;

    public void FixedUpdate() {
        //Can I simulate jumping by making the platforms fall instead of the character jump
        GetComponent<Rigidbody2D>().velocity = Vector2.down * GlobalSettings.speed;
    }

    public int collectPoints() {
        if (pointsCollected) return 0;
        pointsCollected = true;
        return points;
    }
}
