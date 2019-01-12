using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : Platform {

    Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            animator.SetTrigger("Activated");
            collision.gameObject.GetComponent<PlayerController>().Jump();
        }
    }
}
