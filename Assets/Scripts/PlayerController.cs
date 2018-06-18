using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {


    Vector3 velocity;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void FixedUpdate ()
    {
        // Bewegingen wasd * de Vector
        velocity = Input.GetAxis("Vertical") * transform.forward;
        // GetAxis geeft een nummer terug van -1 en 1 dus als je naar links drukt dan doe je -1 * rechts en dat is links
        velocity += Input.GetAxis("Horizontal") * transform.right;
        // Past de snelheid aan van het lopen
        rb.AddForce(velocity, ForceMode.VelocityChange);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500f);
        }
    }
}
