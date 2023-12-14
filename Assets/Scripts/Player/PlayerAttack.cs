using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject hitbox;  // Reference to the hitbox GameObject
    private bool isHitboxActive = false;

    void Update()
    {
        // Check for left mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            // Toggle the state of the hitbox
            isHitboxActive = !isHitboxActive;

            // Activate or deactivate the hitbox based on the state
            if (isHitboxActive)
            {
                ActivateHitbox();
            }
            else
            {
                DeactivateHitbox();
            }
        }
    }

    void ActivateHitbox()
    {
        // Activate the hitbox GameObject
        hitbox.SetActive(true);
    }

    public bool IsAttacking()
    {
        // Return the state of the hitbox (true if active, false otherwise)
        return isHitboxActive;
    }

    public void StopAttack()
    {
        // Deactivate the hitbox GameObject
        DeactivateHitbox();
    }

    void DeactivateHitbox()
    {
        // Deactivate the hitbox GameObject
        hitbox.SetActive(false);
    }
        // Add this method to retrieve the hitbox collider
    public Collider GetHitboxTrigger()
    {
        // Return the collider of the hitbox GameObject
        return hitbox.GetComponent<Collider>();
    }
}
