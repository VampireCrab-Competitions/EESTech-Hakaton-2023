using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    private Vector3 y_offset;

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        float y = player.GetComponent<SpriteRenderer>().bounds.size.y;
        y_offset = new Vector3(0, -y/2, 0);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) + y_offset;
        offset = transform.position - player.transform.position;
        //Debug.Log("Camera fixated on player");
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset + y_offset;
        //Debug.Log("Camera moved with player");
    }
}
