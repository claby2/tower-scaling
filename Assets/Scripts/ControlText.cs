using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlText : MonoBehaviour {
    [Header("Components")]
    public Text Text;

    [Header("States")]
    public bool isVisible = false;

    void Start() {
        Text.enabled = false;
    }

    public void ShowText() {
        Text.enabled = true;
        isVisible = true;
    }
}
