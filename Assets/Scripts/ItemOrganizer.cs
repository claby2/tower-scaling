using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrganizer : MonoBehaviour {
    [Header("Objects")]
    public GameObject Player;

    void Awake() {
        foreach(Transform child in transform) {
            child.gameObject.GetComponent<Item>().Player = Player;
        }
    }

}
