using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [Header("Objects")]
    public GameObject Player;

    [Header("Item Bob")]
    private float originalYPosition;
    private float bobStrength = 0.2f;
    private float bobSpeed = 5f;

    [Header("Object Scripts")]
    private PlayerControl _player;

    void Start() {
        _player = Player.GetComponent<PlayerControl>();
        originalYPosition = transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(gameObject.tag == "Weapon Item") {
                _player.hasWeapon = true;
            }
            if(gameObject.tag == "Checkpoint") {
                _player.LastCheckpoint = transform.position;
            }
            Destroy(gameObject);
        }
    }

    void Update() {
        transform.position = new Vector3(
            transform.position.x, 
            originalYPosition + Mathf.Sin(Time.time / (1 / bobSpeed)) * bobStrength,
            transform.position.z
        );
    }
}
