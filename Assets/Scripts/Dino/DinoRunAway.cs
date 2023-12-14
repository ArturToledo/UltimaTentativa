using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoRunAway : MonoBehaviour
{
    public float moveSpeed = 3f;           // Speed at which the object moves away from the mouse
    public PlayerAttack playerAttack;      // Reference to the PlayerAttack script
    public float coneDistance = 5f;        // Maximum distance for the Dino to react to the mouse
    public float coneAngle = 40f;          // Angle of the cone in which the Dino reacts to the mouse
    public float coneOffsetAngle = 30f;    // Angle to offset the cone to the right

    void Update()
    {
        // Check if the PlayerAttack is active
        if (playerAttack != null && playerAttack.IsAttacking())
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;  // Ensure the Z-coordinate is appropriate for 2D

            // Calculate the direction from the player to the Dino
            Vector3 directionToDino = (transform.position - playerAttack.transform.position).normalized;

            // Calculate the direction from the player to the mouse
            Vector3 directionToMouse = (mousePosition - playerAttack.transform.position).normalized;

            // Check if the Dino is within the cone distance
            if (Vector3.Distance(playerAttack.transform.position, transform.position) <= coneDistance)
            {
                // Apply the cone offset by rotating the direction to the right
                Quaternion offsetRotation = Quaternion.Euler(0f, 0f, -coneOffsetAngle);
                directionToMouse = offsetRotation * directionToMouse;

                // Calculate the dot product to check if the Dino is within the cone
                float dotProduct = Vector3.Dot(directionToDino, directionToMouse);

                // Check if the dot product is within the cone angle range
                if (dotProduct > Mathf.Cos(Mathf.Deg2Rad * (coneAngle / 2)))
                {
                    // Move the object away from the mouse
                    transform.Translate(directionToMouse * moveSpeed * Time.deltaTime);
                }
            }
        }
    }
}
