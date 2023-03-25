using System;   
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class PlayerController : MonoBehaviour
{

    public event Action PlayerHasMoved = delegate { };

    [SerializeField]
    public static int coins;


    [SerializeField]
    public static int health = 10;

    [SerializeField]
    private int armor;

    [SerializeField]
    private int mana;

    [SerializeField]
    public Tilemap floorTilemap;

    [SerializeField]
    private Tilemap colisionTilemap;

    [SerializeField]
    private Tilemap treasureTilemap;

    [SerializeField]
    private Tile[] treasureTiles;

    [SerializeField]
    private Tile key_tile;

    private PlayerMovement _controls;
    private bool hasKey;

    private void Awake()
    {
        _controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    // Start is called before the first frame update 
    void Start()
    {
        coins = 0;
        hasKey = false;
        GameObject key_disp = GameObject.Find("Hatch Key");
        key_disp.GetComponent<Image>().enabled = false;
        _controls.Main.Movement.performed += context => Move(context.ReadValue<Vector2>());
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Move(Vector2 direction)
    {
        direction = new Vector2(direction.x * 0.16f, direction.y * 0.16f);

        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
            
            PlayerHasMoved?.Invoke();

            Vector3Int tile_coords = treasureTilemap.WorldToCell(transform.position);

            Vector3Int exit = treasureTilemap.WorldToCell(new Vector3(terrain_map_generator.exit_x, terrain_map_generator.exit_y,0));
            if (tile_coords == exit)
            {
                hasKey = false;
                level_generator level_gen = GameObject.Find("Level Generator").GetComponent<level_generator>();
                Object old_level = level_gen.level_instance;
                
                level_gen.MakeLevel();
                //SceneManager.LoadScene(0);
            }

            if (treasureTilemap.HasTile(tile_coords))
            {
                TileBase tile = treasureTilemap.GetTile(tile_coords);
                if (String.Equals(tile.name, treasureTiles[0].name))
                {
                    coins += 1;
                    GameObject coin_disp = GameObject.Find("Coin Text TMP");
                    coin_disp.GetComponent<TextMeshProUGUI>().text = coins.ToString();

                }
                else if (String.Equals(tile.name, treasureTiles[1].name))
                {
                    health += 4;
                    GameObject hp_disp = GameObject.Find("HP Text TMP");
                    hp_disp.GetComponent<TextMeshProUGUI>().text = health.ToString();
                }
                else if (String.Equals(tile.name, treasureTiles[2].name))
                {
                    coins += 5;
                    GameObject coin_disp = GameObject.Find("Coin Text TMP");
                    coin_disp.GetComponent<TextMeshProUGUI>().text = coins.ToString();
                }
                else if (String.Equals(tile.name, key_tile.name))
                {
                    GameObject k_disp = GameObject.Find("Hatch Key");
                    //k_disp.GetComponent<Image>().enabled = true;
                    k_disp.GetComponent<Image>().enabled = true;
                    hasKey = true;
                }
                treasureTilemap.SetTile(tile_coords, null);
            }
        }
        
    }
    
    private bool CanMove(Vector2 direction)
    {
        if (floorTilemap == null)
        {
            return false;
        }
        Vector3Int gridPosition = floorTilemap.WorldToCell(transform.position + (Vector3)direction);
        bool isExit = gridPosition == floorTilemap.WorldToCell(new Vector3(terrain_map_generator.exit_x, terrain_map_generator.exit_y, 0));

        return floorTilemap.HasTile(gridPosition) && 
                ((hasKey && isExit) 
                || !colisionTilemap.HasTile(gridPosition));
    }
}

