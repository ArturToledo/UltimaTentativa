using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZRotate : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform

    void Update()
    {
        if (player != null)
        {
            // Face the player by rotating on the z-axis
            FacePlayer();
        }
        else
        {   
            Vector3 directionToPlayer = player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Debug.LogWarning("Player reference not set in the ZRotate script!");

            // Face the opposite direction (180 degrees on the z-axis)
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    void FacePlayer()
    {
        // Calculate the direction from the object to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Set the rotation on the z-axis to face the player
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

