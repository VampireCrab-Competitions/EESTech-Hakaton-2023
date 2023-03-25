using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class terrain_map_generator : MonoBehaviour
{
    public Tilemap terrain_grid;
    public Tile[] upper_wall_tiles;
    public Tile[] lower_wall_tiles;
    public Tile[] left_wall_tiles;
    public Tile[] right_wall_tiles;
    public Tile upper_left_corner;
    public Tile upper_right_corner;
    public Tile exit_tile;
    

    [System.NonSerialized]
    public static float exit_x;
    [System.NonSerialized]
    public static float exit_y;

    private int map_size;

    // Start is called before the first frame update
    void Start()
    {
        map_size = transform.parent.GetComponent<grid_map_fields>().map_size;
        int x = Random.Range((map_size - 1 - map_size / 8), (map_size - 1));
        int y = Random.Range((map_size - 1 - map_size / 8), (map_size - 1));
        terrain_grid.SetTile(new Vector3Int(x, y, 0), exit_tile);
        Vector3 exit_coords = terrain_grid.CellToWorld(new Vector3Int(x, y, 0));
        exit_x = exit_coords.x;
        exit_y = exit_coords.y;


        InstantiateBorderWalls(map_size);
    }

    private void InstantiateBorderWalls(int map_size)
    {
        InstantiateLowerWall(map_size);
        InstantiateUpperWall(map_size);
        InstantiateLeftWall(map_size);
        InstantiateRightWall(map_size);
        InstantiateUpperCorners(map_size);
    }

    private void InstantiateUpperCorners(int map_size)
    {
        terrain_grid.SetTile(new Vector3Int(-1, map_size, 0),
            upper_left_corner);
        terrain_grid.SetTile(new Vector3Int(map_size, map_size, 0),
            upper_right_corner);
        //terrain_grid.SetTile(new Vector3Int(-1, -1, 0), lower_left_corner);
        //terrain_grid.SetTile(new Vector3Int(map_size, -1, 0), lower_right_corner);
    }

    private void InstantiateUpperWall(int map_size)
    {
        for (int x = 0, y = map_size; x < map_size; x++)
        {
            terrain_grid.SetTile(new Vector3Int(x, y, 0),
                upper_wall_tiles[Random.Range(0, upper_wall_tiles.Length)]);
        }
    }

    private void InstantiateLowerWall(int map_size)
    {
        for (int x = -1, y = -1; x <= map_size; x++)
        {
            terrain_grid.SetTile(new Vector3Int(x, y, 0),
                lower_wall_tiles[Random.Range(0, lower_wall_tiles.Length)]);
        }
    }

    private void InstantiateRightWall(int map_size)
    {
        for (int x = map_size, y = 0; y < map_size; y++)
        {
            terrain_grid.SetTile(new Vector3Int(x, y, 0),
                right_wall_tiles[Random.Range(0, right_wall_tiles.Length)]);
        }
    }

    private void InstantiateLeftWall(int map_size)
    {
        for (int x = -1, y = 0; y < map_size; y++)
        {
            terrain_grid.SetTile(new Vector3Int(x, y, 0),
                left_wall_tiles[Random.Range(0, left_wall_tiles.Length)]);
        }
    }
}
