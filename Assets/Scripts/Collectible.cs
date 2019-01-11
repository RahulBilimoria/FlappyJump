using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Moveable {

    private int currencyType;
    private int value;

	// Use this for initialization
	void Start () {
        currencyType = 0;
        value = 1;
	}

    public int getCurrencyType() {
        return currencyType;
    }

    public int getValue() {
        return value;
    }
}
