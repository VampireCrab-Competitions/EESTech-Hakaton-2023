using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class treasure_map : MonoBehaviour
{
    public Tilemap treasure_grid;
    public Tile[] tiles;
    public int treasure_chance;

    private int map_size;
    // Start is called before the first frame update
    void Start()
    {
        map_size = transform.parent.GetComponent<grid_map_fields>().map_size;
        for (int x = 0; x < map_size; x++)
        {
            for (int y = 0; y < map_size; y++)
            {
                if (Random.Range(0, 100) <= treasure_chance)
                {
                    treasure_grid.SetTile(new Vector3Int(x, y, 0), tiles[Random.Range(0, tiles.Length)]);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        //Destroy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
