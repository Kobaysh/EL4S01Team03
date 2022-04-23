using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CollisionHideTile(Vector3 playerPos)
    {
        Vector3Int intPos = Vector3Int.FloorToInt(playerPos);
        return (tilemap.GetTile(intPos).name == "hide");
    }

    public bool CollisionGoalTile(Vector3 playerPos)
    {
        Vector3Int intPos = Vector3Int.FloorToInt(playerPos);
        return (tilemap.GetTile(intPos).name == "goal");
    }
}
