using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChooser : MonoBehaviour {

    public Sprite[] sprites;

    public Sprite getSprite(int i) {
        return sprites[i];
    }

    public Sprite getRandomSprite() {
        return sprites[Random.Range(0, sprites.Length-1)];
    }
}
