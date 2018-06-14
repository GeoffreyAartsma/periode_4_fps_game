using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    Vector3 velocity;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void FixedUpdate ()
    {
        // Detect Input
        velocity = Input.GetAxis("Vertical") * transform.forward;
        velocity += Input.GetAxis("Horizontal") * transform.right;
        rb.AddForce(velocity, ForceMode.VelocityChange);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500f);
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
