using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public event Action PlayerHasMoved = delegate { };

    [SerializeField] public static int coins;

    [SerializeField] public static int health = 10;

    [SerializeField] private int armor;

    [SerializeField] private int mana;

    [SerializeField] private Tilemap floorTilemap;

    [SerializeField] private Tilemap colisionTilemap;

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