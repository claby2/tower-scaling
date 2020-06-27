using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitbox : MonoBehaviour {
    
    public bool IsColliding = false;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Level")) {
            IsColliding = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Level")) {
            IsColliding = false;
        }
    }
}
