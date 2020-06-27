using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour {
    [Header("Objects")]
    public GameObject Crosshair;
    public GameObject Player;

    [Header("Components")]
    public SpriteRenderer SpriteRenderer;

    [Header("Object Scripts")]
    private PlayerControl _player; 

    void Start() {
        _player = Player.GetComponent<PlayerControl>();
    }

    void Update() {
        if(Input.GetMouseButton(0) && _player.hasWeapon) {
            SpriteRenderer.enabled = true;
            Vector3 crosshairPosition = Crosshair.transform.position;
            Vector3 aimDirection = (crosshairPosition - Player.transform.position).normalized;
            float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg);
            transform.eulerAngles = new Vector3(0, 0, angle - 45f);

            Vector3 weaponPosition = transform.position;
            weaponPosition.x = Player.transform.position.x + (1.5f * Mathf.Cos(angle * (Mathf.PI / 180)));
            weaponPosition.y = Player.transform.position.y + (1.5f * Mathf.Sin(angle * (Mathf.PI / 180)));
            transform.position = weaponPosition;
        } else {
            SpriteRenderer.enabled = false;
        }

    }
}
