using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 movement;
    Rigidbody rb;
    public float speed;
    Camera cam;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        rb.velocity = movement;
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z + -15);
    }
}
