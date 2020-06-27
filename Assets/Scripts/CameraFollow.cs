using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("Player")]
    public GameObject Player;

    [Header("Smoothing")]
    private float smoothing = 0.1f;

    void FixedUpdate() {
        if(transform.position != Player.transform.position) {
            Vector3 targetPosition = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
