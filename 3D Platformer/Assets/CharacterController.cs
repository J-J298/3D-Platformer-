using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float maxSpeed = 26.0f;
    float rotation = 0.0f;
    Rigidbody myRigidbody;


    GameObject cam;
    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    float camRotation = 0.0f;
    public float jumpForce = 300.0f;    

    
    void Start()
    {
       
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
    }

    
    
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed;
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);
        //transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed;

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));
        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
        }

    }
}
