using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMouse : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;  // Distance from the camera

        // Convert the mouse position to world space
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);

        // Rotate the player to face the mouse position
        Vector3 direction = targetPosition - transform.position;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

