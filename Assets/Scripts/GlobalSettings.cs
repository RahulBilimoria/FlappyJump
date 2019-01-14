using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour {

    public static bool gameStarted = false;
    public static float speed = 0.0f;

    public static GameObject player;

    private void Awake() {
        player = GameObject.Find("Player");  
    }
}
