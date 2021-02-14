using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
    // allows the pickup objects to rotate at the given angles 
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
