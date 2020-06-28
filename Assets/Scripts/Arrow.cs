using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    [Header("Components")]
    public Rigidbody2D RigidBody;

    [Header("Movement")]
    public int Direction;
    private float arrowSpeed = 50f;

    [Header("States")]
    private int boundariesExited = 0;

    void Start() {
        RigidBody.velocity = new Vector2(Direction * arrowSpeed, RigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(!(collision.CompareTag("Hostile") || collision.CompareTag("Boundary"))) {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Boundary")) {
            boundariesExited++;
            if(boundariesExited >= 2) {
                // Only destroy after two (or more) boundaries have been exited as arrows spawn inside a boundary
                Destroy(gameObject);
            }
        }
    }
}
