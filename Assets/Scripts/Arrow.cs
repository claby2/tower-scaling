using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    [Header("Components")]
    public Rigidbody2D RigidBody;

    [Header("Movement")]
    public int Direction;
    private float arrowSpeed = 50f;

    void Start() {
        RigidBody.velocity = new Vector2(Direction * arrowSpeed, RigidBody.velocity.y);
    }

    void Update() {
        if(transform.position.x >= 40 || transform.position.x <= -40) { // If outside of screen
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(!collision.CompareTag("Hostile")) {
            Destroy(gameObject);
        }
    }
}
