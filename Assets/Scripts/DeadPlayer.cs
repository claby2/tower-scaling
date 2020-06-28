using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour {
    [Header("Components")]
    public Rigidbody2D RigidBody;
    
    [Header("Private")]
    private float thrust = 10.0f;
    private float revSpeed;

    void Start() {
        revSpeed = (Random.value > 0.5f ? 1 : -1) * 360f;
        RigidBody.rotation = Random.Range(0f, 360f);
        RigidBody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        RigidBody.AddForce(transform.right * (Random.value > 0.5f ? 1 : -1) * thrust, ForceMode2D.Impulse);
    }

    void FixedUpdate() {
        RigidBody.MoveRotation(RigidBody.rotation + revSpeed * Time.fixedDeltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Boundary")) {
            Destroy(gameObject);
        }
    }

}
