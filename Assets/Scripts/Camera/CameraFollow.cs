using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the player's Transform

    public Vector3 offset = new Vector3(0f, 0f, -10f);  // Adjust the offset as needed

    void LateUpdate()
    {
        if (target != null)
        {
            // Set the camera's position to the player's position + offset
            transform.position = target.position + offset;
        }
    }
}
