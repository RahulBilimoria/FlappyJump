using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData : MonoBehaviour {
    
    //Upgrades
    public float jumpHeightModifier;
    public int jumpHeightModifierIndex;
    public float pointsMultiplier;
    public int pointsMultiplierIndex;
    public int gemValueMultiplier;
    public int gemValueMultiplierIndex;

    //High Scores
    public float bestHeight;
    public float bestScore;

    //Other Player Settings
    public int currency;

    public void loadDefault() {
        jumpHeightModifier = 1.0f;
        jumpHeightModifierIndex = 0;
        pointsMultiplier = 1.0f;
        pointsMultiplierIndex = 0;
        gemValueMultiplier = 1;
        gemValueMultiplierIndex = 0;

        bestHeight = 0;
        bestScore = 0;

        currency = 0;
    }
}
