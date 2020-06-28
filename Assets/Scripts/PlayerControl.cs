using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [Header("Components")]
    public Rigidbody2D RigidBody;

    [Header("Objects")]
    public GameObject GroundHitbox;
    public GameObject DeadPlayers;
    public GameObject DeadPlayer;

    [Header("Player States")]
    public bool hasWeapon = false;
    public Vector3 LastCheckpoint = new Vector3(0, 0, 0);

    [Header("Movement")]
    private float moveSpeed = 10f;         // Horizontal move speed
    private float horizontalInput;         // Horizontal Input from GetAxisRaw
    private float jumpHeight = 20f;        // Y velocity when jump is issued
    private float jumpRemember;            // Jump timer
    private float jumpRememberTime = 0.2f; // Delay that player can jump when no longer in contact with ground
    private bool executeJump;              // Represents if the player would like to jump

    [Header("Object Scripts")]
    private GroundHitbox _groundHitbox;

    public void GoToCheckpoint() {
        GameObject deadPlayer = Instantiate(DeadPlayer, transform.position, Quaternion.identity);
        deadPlayer.transform.parent = DeadPlayers.transform;
        transform.position = LastCheckpoint;
    }

    void Start() {
        _groundHitbox = GroundHitbox.GetComponent<GroundHitbox>();
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(jumpRemember > 0) 
            jumpRemember -= Time.deltaTime;  // Decrease jump timer 
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
            jumpRemember = jumpRememberTime; // Maximize jump timer
        }
        if(jumpRemember > 0 && _groundHitbox.IsColliding) {
            jumpRemember = 0;                // Make sure player cannot jump straight away after
            executeJump = true;
        }
    }

    void FixedUpdate() {
        RigidBody.velocity = new Vector2(horizontalInput * moveSpeed, RigidBody.velocity.y);
        if(executeJump) {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x, jumpHeight);
            executeJump = false;
        }
    }
}
