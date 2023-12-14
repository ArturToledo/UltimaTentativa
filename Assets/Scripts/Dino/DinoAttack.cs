using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAttack : MonoBehaviour
{
    public int attackDamage = 10; // Adjust the damage value as needed
    public float attackRange = 1f; // Adjust the attack range as needed
    public LayerMask playerLayer; // Set the player layer in the Inspector

    void Update()
    {
        // Check for player within attack range
        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayers)
        {
            // Assuming the player has a "HealthBar" script
            HealthBar healthBar = player.GetComponent<HealthBar>();

            if (healthBar != null)
            {
                // Player is within attack range, perform the attack
                AttackPlayer(healthBar);
            }
        }
    }

    void AttackPlayer(HealthBar healthBar)
    {
        Debug.Log("Dino is attacking the player!");

        // You can add more complex attack logic here if needed
        // For now, let's just subtract the attack damage from the player's health
        healthBar.SetHealth(healthBar.slider.value - attackDamage);
    }

    // Visualizing the attack range in the Scene view (optional)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
