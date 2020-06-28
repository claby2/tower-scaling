using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnBlock : MonoBehaviour {
    [Header("Game Objects")]
    public GameObject Player;

    [Header("Tile")]
    public Tilemap Tilemap;
    public Tile BlockTile;

    [Header("Object Scripts")]
    private PlayerControl _player; 

    struct Block {
        public Vector3Int position;
        public float timePlaced;
    };
    private Vector3Int currentPosition;
    private List<Block> blocks = new List<Block>();
    private float blockDuration = 0.2f; // The amount of time blocks last after being placed

    void Start() {
        _player = Player.GetComponent<PlayerControl>();
    }

    bool HasTile(Tile tile) {
        return Tilemap.GetTile(currentPosition) == tile;
    }

    void Update() {
        currentPosition = new Vector3Int(
            (int)Mathf.Floor(transform.position.x),
            (int)Mathf.Floor(transform.position.y),
            (int)Tilemap.transform.position.z
        );
        if(Input.GetMouseButton(0) && HasTile(null) && _player.hasWeapon) {
            Tilemap.SetTile(currentPosition, BlockTile);
            Block block;
            block.position = currentPosition;
            block.timePlaced = Time.time;
            blocks.Add(block);
        }

        for(int i = 0; i < blocks.Count; i++) {
            if(Time.time - blocks[i].timePlaced >= blockDuration) {
                Tilemap.SetTile(blocks[i].position, null);
                blocks.RemoveAt(i);
            }
        }
    }
}
