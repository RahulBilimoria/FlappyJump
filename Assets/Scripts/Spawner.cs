using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //List of all the spawnable objects
    ObjectPooler objectPool;

    public float spawnInterval = 1.0f;
    private float spawnLastTime;

    //Size of the spawnable area
    float leftPos, rightPos;
    //Time variance for spawning an object (might move to the object pooler script)
    float variance = 0.25f;

    //Speed increase for platforms and last increment time (might move to platform script)
    /*public float platformSpeedIncrease = 0.01f;
    public float platformSpeedIncreaseInterval = 0.1f;
    float platformSpeedLastTime;*/

	// Use this for initialization
	void Start () {
        objectPool = gameObject.GetComponent<ObjectPooler>();

        leftPos = transform.parent.transform.position.x; ;
        rightPos = leftPos + transform.parent.transform.localScale.x;

        spawnLastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //Platform Speed Interval
        /*if (platformSpeedIncrease != 0 && Time.time - platformSpeedLastTime >= platformSpeedIncreaseInterval) {
            //as the speed increases, the interval between platforms has to decrease or there will be too little platforms on the screen
            Platform.IncreaseSpeed(platformSpeedIncrease);
            platformSpeedLastTime = Time.time;
        }*/

        //Platform Spawn Interval
		if (Time.time - spawnLastTime >= spawnInterval + Random.Range(-variance, variance)) {
            //add option to spawn more than 1 platform at a time based on %
            spawnLastTime = Time.time;
            Vector2 pos = new Vector2(Random.Range(leftPos, rightPos), transform.position.y);
            GameObject obj = objectPool.getPooledObject();
            InitializeGameObject(obj, pos);
        }
	}

    void InitializeGameObject(GameObject obj, Vector2 pos) {
        if (obj == null) return;
        obj.transform.position = pos;
        obj.SetActive(true);
    }
}
