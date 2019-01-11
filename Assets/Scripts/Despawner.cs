using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Spawnable" || collision.gameObject.tag == "Floor") {
            DespawnObject(collision.gameObject);
        }
    }

    void DespawnObject(GameObject obj) {
        obj.SetActive(false);
    }
}
