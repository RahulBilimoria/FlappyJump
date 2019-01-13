using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //List of all the spawnable objects
    ObjectPooler objectPool;
    Bounds bb;

    public float spawnInterval = 1.0f;
    private float spawnLastTime;

    public bool chooseSprite = false;
    public bool randomX = true, randomY = true;
    public bool alternateX = false, alternateY = false;

    //Time variance for spawning an object (might move to the object pooler script)
    float variance = 0.25f;

    //Speed increase for platforms and last increment time (might move to platform script)
    /*public float platformSpeedIncrease = 0.01f;
    public float platformSpeedIncreaseInterval = 0.1f;
    float platformSpeedLastTime;*/

	// Use this for initialization
	void Start () {
        objectPool = gameObject.GetComponent<ObjectPooler>();
        bb = GetComponent<BoxCollider2D>().bounds;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 spawnPosition;
        if (!GlobalSettings.gameStarted) {
            spawnLastTime = Time.time;
            return;
        }
        spawnPosition.x = bb.min.x;
        spawnPosition.y = bb.min.y;
        if (randomX) {
            spawnPosition.x = Random.Range(bb.min.x, bb.max.x);
        } else if (alternateX) {
            //spawnPosition.x = bb.max.x;
        }
        if (randomY) {
            spawnPosition.y = Random.Range(bb.min.y, bb.max.y);
        } else if (alternateY) {
            //spawnPosition.y = bb.max.y;
        }
        //Platform Speed Interval
        /*if (platformSpeedIncrease != 0 && Time.time - platformSpeedLastTime >= platformSpeedIncreaseInterval) {
            //as the speed increases, the interval between platforms has to decrease or there will be too little platforms on the screen
            Platform.IncreaseSpeed(platformSpeedIncrease);
            platformSpeedLastTime = Time.time;
        }*/

        //Platform Spawn Interval
		if (Time.time - spawnLastTime >= (spawnInterval + Random.Range(-variance, variance)) / GlobalSettings.speed) {
            //add option to spawn more than 1 platform at a time based on %
            spawnLastTime = Time.time;
            Vector2 pos = spawnPosition;
            GameObject obj = objectPool.getPooledObject();
            InitializeGameObject(obj, pos);
        }
	}

    void InitializeGameObject(GameObject obj, Vector2 pos) {
        if (obj == null) return;
        obj.transform.position = pos;
        if (chooseSprite) {
            obj.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteChooser>().getRandomSprite();
        }
        obj.SetActive(true);
        //print(obj.GetComponent<Rigidbody2D>().Cast(Vector2.down, null));
        //if (obj.GetComponent<Rigidbody2D>().Cast(Vector2.down, null, 0.75f) != 0) return;
    }
}
