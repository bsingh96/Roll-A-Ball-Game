using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player; // player object variable declaration
    private Vector3 offset; // offset variable declaration
    void Start()
    {
        offset = transform.position - player.transform.position;  // determine the offset between the player and the movement
     }

   
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;// sets the camera view to move along with the player 
    }
}
 