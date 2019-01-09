using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private static float speed = 1;

    void Start() {
        resetPlatform();
    }

    public void resetPlatform() {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }

    public static void IncreaseSpeed(float value) {
        if (value <= 0) return;
        speed += value;
    }
}
