using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 movement;
    Vector3 prevPos;
    Rigidbody rb;
    public float speed;
    public float cameraShift= 3, cameraSpeed = 3;
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
        //cam.transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * cameraShift, transform.position.y + 10, transform.position.z + -15 + Input.GetAxis("Vertical") * cameraShift);
        cam.transform.position = Vector3.Lerp(prevPos, new Vector3(transform.position.x + Input.GetAxis("Horizontal") * cameraShift, transform.position.y + 10, transform.position.z + -15 + Input.GetAxis("Vertical")), Time.deltaTime * cameraSpeed);
        prevPos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 15);
    }
}
