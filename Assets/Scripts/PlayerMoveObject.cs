using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveObject : MonoBehaviour {

    //Hoeveel units afstand de raycast kan
    [SerializeField]
    int range;

    //Bool is als iets waar of niet waar is
    public bool isGrabbing;

    Rigidbody grabbingRigidbody;
    float grabbingDisctance;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isGrabbing)
        {
            //Gravity gaat uit als je het blokje oppakt
            grabbingRigidbody.useGravity = false;
            //De afstand tussen de player en het blokje
            Vector3 boxPosition = transform.position + transform.TransformDirection(Vector3.forward) * grabbingDisctance;
            grabbingRigidbody.MovePosition(boxPosition);
        }

        else if (grabbingRigidbody)
        {
            //Als linker muisknop
            grabbingRigidbody.useGravity = true;
        }
        
    }

    void Update()
    {
        // If left mouse button is pressed.
        if (Input.GetMouseButton(0))
        {
            // The integer representation in binary is a bunch of 1's and 0's.  One is represented by 0001. 
            // The process of bit-shifting (<<) moves the numbers in the binary system to the left.
            // For example, a 1 << 2 shifts the 0001 two steps to the left, resulting in 0100.
            // Collide only with the layer grabable (10).
            int layerMask = 1 << 10;

            RaycastHit hit;

            // Does the ray intersect any objects excluding the player layer
            if (!isGrabbing && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
            {
                if (!hit.transform.GetComponent<SnapToGrid>().isSnapped)
                {

                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    grabbingDisctance = hit.distance;
                    grabbingRigidbody = hit.rigidbody;

                    isGrabbing = true;
                }
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            }
        }

        else
        {
            isGrabbing = false;
        }
    }
}
