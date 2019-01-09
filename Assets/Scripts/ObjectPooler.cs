using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler current;

    public GameObject pooledObject;
    public List<GameObject> pooledObjects;

    public int poolSize = 10;
    public bool canGrow = true;

    void Awake() {
        current = this;
    }

    // Use this for initialization
    void Start() {
        pooledObjects = new List<GameObject>();

        for (int x = 0; x < poolSize; x++) {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObject() {
        for (int x = 0; x < poolSize; x++) {
            if (!pooledObjects[x].activeInHierarchy) return pooledObjects[x];
        }
        if (canGrow) {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            poolSize++;
            return obj;
        }
        return null;
    }
}
