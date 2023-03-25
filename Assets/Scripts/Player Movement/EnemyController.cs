using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public static int health = 10;

    [SerializeField] private Tilemap floorTilemap;

    [SerializeField] private Tilemap colisionTilemap;
    
    [SerializeField] public PlayerController playerController;
    
    private void Awake()
    {
        // if (playerController != null)
        // {
        //     playerController.PlayerHasMoved += OnThingHappened;
        // }
    }

    private void OnEnable()
    {
        if (playerController != null)
        {
            playerController.PlayerHasMoved += ItIsYourTurn;
        }
    }

    private void OnDisable()
    {
        // PlayerController.PlayerHasMoved -= ItIsYourTurn();
        
        if (playerController != null)
        {
            playerController.PlayerHasMoved -= ItIsYourTurn;
        }
    }

    void ItIsYourTurn()
    {
        Vector2 movementVector;

        switch (UnityEngine.Random.Range(0, 5))
        {
            case 0:
                movementVector = new Vector2(0, 0);
                Move(movementVector);
                break;
            case 1:
                movementVector = new Vector2(1, 0);
                Move(movementVector);
                break;
            case 2:
                movementVector = new Vector2(0, 1);
                Move(movementVector);
                break;
            case 3:
                movementVector = new Vector2(-1, 0);
                Move(movementVector);
                break;
            case 4:
                movementVector = new Vector2(0, -1);
                Move(movementVector);
                break;
        }
    }

    // Start is called before the first frame update 
    void Start()
    {
    }

    private void Update()
    {
        CheckIfDead();
    }

    private void Move(Vector2 direction)
    {
        direction = new Vector2(direction.x * 0.16f, direction.y * 0.16f);
        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = floorTilemap.WorldToCell(transform.position + (Vector3)direction);

        return floorTilemap.HasTile(gridPosition) && !colisionTilemap.HasTile(gridPosition);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        CheckIfDead();
    }

    public void CheckIfDead()
    {
        if (health <= 0)
        {
            PlayerController.coins += 15;
            EnemyKilled();
        }
    }

    public void EnemyKilled()
    {
        Destroy(gameObject);
    }
}