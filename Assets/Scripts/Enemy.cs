using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private bool canKill;
    private int value;

	// Use this for initialization
	void Start () {
        canKill = true;
        value = 1;
	}

    void Update() {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * GlobalSettings.speed;
    }

    public bool getCanKill() {
        return canKill;
    }

    public int getValue() {
        return value;
    }
}
