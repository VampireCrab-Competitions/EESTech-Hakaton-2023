using System;   
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class level_generator : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject level_prefab;

    public UnityEngine.Object level_instance;

    public void MakeLevel()
    {
        Object old_instance = level_instance;
        
        TextMeshProUGUI depth = GameObject.Find("Depth Text").GetComponent<TextMeshProUGUI>();
        
        // int curr_depth = int.Parse(depth.text) + 1;
        // depth.text = curr_depth.ToString();
        
        level_instance = Instantiate(level_prefab);

        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        player.transform.position = new Vector3(0.96f, 0.96f, 0.0f);
        playerController.floorTilemap = GameObject.Find("Tile Map").GetComponent<Tilemap>();
        Destroy(old_instance);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //MakeLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
