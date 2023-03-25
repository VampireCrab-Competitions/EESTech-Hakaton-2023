using System;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public event Action PlayerHasMoved = delegate { };

    [SerializeField] public static int coins;

    [SerializeField] public static int health = 10;

    [SerializeField] private int armor;

    [SerializeField] private int mana;

    [SerializeField] private Tilemap floorTilemap;

    [SerializeField] private Tilemap colisionTilemap;

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
            if (treasureTilemap.HasTile(tile_coords))
            {
                TileBase tile = treasureTilemap.GetTile(tile_coords);
                if (String.Equals(tile.name, treasureTiles[0].name))
                {
                    coins += 1;
                    GameObject coin_disp = GameObject.Find("Coin Text TMP");
                    coin_disp.GetComponent<TextMeshProUGUI>().text = coins.ToString();

                } else if (String.Equals(tile.name, treasureTiles[1].name))
                {
                    health += 4;
                    GameObject hp_disp = GameObject.Find("HP Text TMP");
                    hp_disp.GetComponent<TextMeshProUGUI>().text = health.ToString();
                } else if (String.Equals(tile.name, treasureTiles[2].name))
                {
                    coins += 5;
                    GameObject coin_disp = GameObject.Find("Coin Text TMP");
                    coin_disp.GetComponent<TextMeshProUGUI>().text = coins.ToString();
                } else if (String.Equals(tile.name, key_tile.name))
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
        Vector3Int gridPosition = floorTilemap.WorldToCell(transform.position + (Vector3)direction);

        return floorTilemap.HasTile(gridPosition) && !colisionTilemap.HasTile(gridPosition);
    }
    
    public int GetMana()
    {
        return mana;
    }

    public void SetMana(int mana)
    {
        this.mana = mana;
    }

    public int GetArmor()
    {
        return armor;
    }

    public void SetArmor(int armor)
    {
        this.armor = armor;
    }

    // public int GetCoins()
    // {
    //     return coins;
    // }
    //
    // public void SetCoins(int coins)
    // {
    //     this.coins = coins;
    // }

    // public int GetHealth()
    // {
    //     return health;
    // }
    //
    // public void SetHealth(int health)
    // {
    //     this.health = health;
    // }
    
}

