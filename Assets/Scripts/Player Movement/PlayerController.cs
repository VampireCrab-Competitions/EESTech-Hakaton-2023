using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap;
    
    [SerializeField]
    private Tilemap colisionTilemap;
    
    private PlayerMovement controls;

    private void Awake()
    {
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update 
    void Start()
    {
        controls.Main.Movement.performed += context => Move(context.ReadValue<Vector2>());
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

    // Update is called once per frame
    void Update()
    {
        
    }
}




// void Start()
// {
//     controls.Main.Movement.performed += context => Move(context.ReadValue<Vector2>());
// }
//
// private void Move(Vector2 direction)
// {
//     if (CanMove(direction))
//     {
//         transform.position += (Vector3)direction;
//
//     }
// }
//
// private bool CanMove(Vector2 direction)
// {
//     Vector3Int gridPosition = floorTilemap.WorldToCell(transform.position + (Vector3)direction);
//
//     return floorTilemap.HasTile(gridPosition) && !colisionTilemap.HasTile(gridPosition);
// }