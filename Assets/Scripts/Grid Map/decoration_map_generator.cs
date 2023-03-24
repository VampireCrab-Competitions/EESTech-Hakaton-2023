using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class decoration_map_generator : MonoBehaviour
{
    public Tilemap decoration_grid;
    public Tile[] tiles;
    public int decor_chance;

    private int map_size;
    // Start is called before the first frame update
    void Start()
    {
        map_size = transform.parent.GetComponent<grid_map_fields>().map_size;
        for (int x = 0; x < map_size; x++)
        {
            for (int y = 0; y < map_size; y++)
            {
                if(Random.Range(0,100) <= decor_chance){
                    decoration_grid.SetTile(new Vector3Int(x, y, 0), tiles[Random.Range(0, tiles.Length)]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
