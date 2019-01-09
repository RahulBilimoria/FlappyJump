using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    ObjectPooler platformPooler;
    ObjectPooler springPlatformPooler;

    public float platformSpawnInterval = 1.0f;
    float platformSpawnLastTime;

    float leftPos, rightPos;
    float variance = 0.25f;

    public float platformSpeedIncrease = 0.01f;
    public float platformSpeedIncreaseInterval = 0.1f;
    float platformSpeedLastTime;

	// Use this for initialization
	void Start () {
        platformPooler = GetComponent<ObjectPooler>();
        platformSpawnLastTime = platformSpeedLastTime = Time.time;
        leftPos = transform.position.x;
        rightPos = leftPos + transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - platformSpeedLastTime >= platformSpeedIncreaseInterval) {
            //as the speed increases, the interval between platforms has to decrease or there will be too little platforms on the screen
            Platform.IncreaseSpeed(platformSpeedIncrease);
            platformSpeedLastTime = Time.time;
        }

		if (Time.time - platformSpawnLastTime >= platformSpawnInterval + Random.Range(-variance, variance)) {
            //add option to spawn more than 1 platform at a time
            platformSpawnLastTime = Time.time;
            Vector2 pos = new Vector2(Random.Range(leftPos, rightPos), transform.position.y);
            GameObject obj = platformPooler.getPooledObject();
            InitializeGameObject(obj, pos);
        }
	}

    void InitializeGameObject(GameObject obj, Vector2 pos) {
        if (obj == null) return;
        obj.transform.position = pos;
        obj.SetActive(true);
        obj.GetComponent<Platform>().resetPlatform();
    }

    void DespawnObject(GameObject obj) {
        obj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Floor") {
            DespawnObject(collision.gameObject);
        }
    }
}
