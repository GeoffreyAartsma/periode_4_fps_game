using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{

    public Transform playerBody;
    public float mouseSensitivity;

    float xAxisClamp = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Waar op je scherm je muis staat
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Hoeveel je muis geroteerd moet worden
        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        //Hoeveel graden je ergens naar toe kijkt omhoog en omlaag
        xAxisClamp -= rotAmountY;

        //Rotaties die je body en camera op dit moment hebben in x,y,z graden (Vector3)
        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        //Voegt de rotatie toe aan de camera van de muis
        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;

        //Zorgt ervoor dat je achteruit salto's kan maken of dat je helemaal kunt doordraaien met je camera 
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        //Zorgt ervoor dat de rotatie over x,y,z as wordt vertaald naar quaternion (quaternion is een 4d rotatie matrix voor matrixberekenen)
        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
    }
}

