using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Moveable {

    public bool canKill = true;
    private int value;

	// Use this for initialization
	void Start () {
        canKill = true;
        value = 1;
	}

    public bool getCanKill() {
        return canKill;
    }

    public int getValue() {
        return value;
    }
}
