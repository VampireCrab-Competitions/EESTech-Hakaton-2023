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
    private float prev_rot;

    // Start is called before the first frame update
    void Start()
    {
        prev_rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = (terrain_map_generator.exit_y - player.transform.position.y) / (terrain_map_generator.exit_x - player.transform.position.x);
        rotation = Mathf.Atan(rotation) * 180.0f / Mathf.PI - 90.0f;
        if (rotation - prev_rot < -90.0f)
        {
            compass_hand.transform.Rotate(new Vector3(0, 0, rotation - prev_rot - 180.0f));
        } else
        {
            compass_hand.transform.Rotate(new Vector3(0, 0, rotation - prev_rot));
        }
        prev_rot = rotation;
    }
}
