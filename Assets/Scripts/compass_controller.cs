using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class compass_controller : MonoBehaviour
{
    public GameObject player;
    public GameObject compass_hand;

    private GameObject terrain_map; 
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotation = (terrain_map_generator.exit_y - player.transform.position.y) / (terrain_map_generator.exit_x - player.transform.position.x);
        rotation = Mathf.Atan(rotation) * 180.0f / Mathf.PI - 90.0f;
        if(terrain_map_generator.exit_y - player.transform.position.y < 0 || terrain_map_generator.exit_x - player.transform.position.x > 0)
        {
            rotation += 180.0f;
        }
        if (terrain_map_generator.exit_y - player.transform.position.y < 0 && terrain_map_generator.exit_x - player.transform.position.x < 0)
        {
            rotation -= 180.0f;
        }
        compass_hand.transform.eulerAngles = new Vector3(0.0f, 0.0f, rotation);
    }
}
