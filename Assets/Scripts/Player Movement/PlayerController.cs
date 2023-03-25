using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public static int coins;
    
    [SerializeField]
    public static int health=10;

    [SerializeField]
    private int armor;

    [SerializeField]
    private int mana;
    
    [SerializeField]
    private Tilemap floorTilemap;
    
    [SerializeField]
    private Tilemap colisionTilemap;

    [SerializeField]
    private Tilemap treasureTilemap;

    [SerializeField]
    private Tile[] treasureTiles;

    private PlayerMovement _controls;
    
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

    public int GetHealth()
    {
        return health;
    }
    
    public void SetHealth(int health)
    {
        health = health;
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
    
    public int GetCoins()
    {
        return coins;
    }
}
