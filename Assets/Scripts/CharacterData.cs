using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour {

    //make whole class serializable??
    
    //Upgrades
    public float jumpHeightModifier = 1.0f;
    public float pointsMultiplier = 1.0f;
    public int gemValueMultiplier = 1;

    //High Scores
    public float bestHeight = 0.0f;
    public float bestScore = 0.0f;

    //Other Player Settings
    public string playerName = "Default";
}
