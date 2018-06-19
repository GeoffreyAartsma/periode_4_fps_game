using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour {

    [SerializeField]
    GameObject player;

    public bool isSnapped;
    public string targetName;

    [SerializeField]
    Vector3 snapOffset;

    private void OnTriggerEnter(Collider other)
    {
        SnapToGrid otherScript = other.GetComponent<SnapToGrid>();
        if (other.transform.name == targetName && !otherScript.isSnapped)
        {
            player.GetComponent<PlayerMoveObject>().isGrabbing = false;
            other.transform.position = transform.position + snapOffset;
            otherScript.isSnapped = true;
            isSnapped = true;
        }
    }
}
