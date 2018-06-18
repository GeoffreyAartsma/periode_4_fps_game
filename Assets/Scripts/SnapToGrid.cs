using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour {

    [SerializeField]
    GameObject player;

    public bool isSnapped;

    string targetName;

    void Start()
    {
        if (transform.name == "Ground Plate")
        {
            targetName = "Middle Piece";
        }
        else if (transform.name == "Middle Piece")
        {
            targetName = "Top Piece";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == targetName)
        {
            player.GetComponent<PlayerMoveObject>().isGrabbing = false;
            other.transform.position = transform.position + Vector3.up;
        }
    }
}
