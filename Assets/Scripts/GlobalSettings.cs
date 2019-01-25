using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour {

    public static bool gameStarted = false;
    public static float speed = 0.0f;

    public static GameObject player;
    public static CharacterData characterData = new CharacterData();

    private void Awake() {
        player = GameObject.Find("Player");
        characterData = SaveData.LoadGameData();
        if (characterData == null) {
            characterData.loadDefault();
        }
    }
}
