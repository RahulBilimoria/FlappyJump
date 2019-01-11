using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {

    public Vector2 direction = new Vector2(0, -1);
    public float speedModifier = 1.0f;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * GlobalSettings.speed * speedModifier;
	}
}
