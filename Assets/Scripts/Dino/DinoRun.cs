using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoRun : MonoBehaviour
{
    public Transform player;       // Reference to the player's transform
    public float moveSpeed = 3f;    // Speed at which the object moves towards the player
    public float detectionRange = 5f;  // Detection range to start moving towards the player

    void Update()
    {
        // Check if the player is within the detection range
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // Calculate the direction towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Move the object towards the player
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
        }
    }
}
