using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour {
    [Header("Objects")]
    public Camera Camera;

    void Start() {
        Cursor.visible = false; // Hide system cursor
    }

    void Update() {
        Vector2 cursorPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
    }
}
