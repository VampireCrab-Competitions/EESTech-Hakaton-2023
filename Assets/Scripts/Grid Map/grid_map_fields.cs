using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grid_map_fields : MonoBehaviour
{
    public int map_size;

    public void MakeLevel()
    {
        TextMeshProUGUI depth = GameObject.Find("Depth Text").GetComponent<TextMeshProUGUI>();

        int curr_depth = int.Parse(depth.text) + 1;
        depth.text = curr_depth.ToString();

        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        player.transform.position = new Vector3(0.96f, 0.96f, 0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}