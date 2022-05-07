using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
CODE BY: Jonas Vrieling
TEST CODE FOR "GARDEN GHOST" (working title)

This code rotates all the sprites that are the child of the main gameobject (where this script is) and makes them face the camera.
 
*/

public class Billboard : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        transform.forward = cam.transform.forward;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // transform.LookAt(cam.transform);

       // transform.rotation = new Quaternion.Euler(transform.rotation.eulerAngles.y, 0f, 0f);
    }
}
