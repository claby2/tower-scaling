using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {
    [Header("Objects")]
    public GameObject Arrow;

    [Header("State")]
    public bool ShootLeft;

    [Header("Private")]
    private float shootSpeed = 0.5f;
    private float shootTimer = 0.5f;
    private float xPosition = 30;

    void Start() {
        Vector3 currentPosition = transform.position;
        if(ShootLeft) { 
            currentPosition.x = xPosition;
        } else {
            currentPosition.x = -xPosition;
        }
        transform.position = currentPosition;
    }

    void Shoot() {
        GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.identity);
        if(ShootLeft) {
            arrow.GetComponent<Arrow>().Direction = -1; // Go left
        } else {
            arrow.GetComponent<SpriteRenderer>().flipX = true;
            arrow.GetComponent<Arrow>().Direction = 1; // Go right
        }
    }

    void Update() {
        if(shootTimer <= 0) {
            Shoot();
            shootTimer = shootSpeed;
        } else {
            shootTimer -= Time.deltaTime;
        }
        
    }
}
