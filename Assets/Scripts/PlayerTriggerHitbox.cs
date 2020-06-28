using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHitbox : MonoBehaviour {
    [Header("Objects")]
    public GameObject Player;

    [Header("Scripts")]
    private PlayerControl _player;

    void Start() {
        _player = Player.GetComponent<PlayerControl>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Hostile") || collision.CompareTag("Boundary")) {
            _player.GoToCheckpoint();
        }
    }

}
