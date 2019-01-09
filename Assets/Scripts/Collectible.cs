using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    private int currencyType;
    private int value;

	// Use this for initialization
	void Start () {
        currencyType = 0;
        value = 1;
	}

    void Update() {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * GlobalSettings.speed;
    }

    public int getCurrencyType() {
        return currencyType;
    }

    public int getValue() {
        return value;
    }
}
