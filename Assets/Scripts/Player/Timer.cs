using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float initialTime = 10f;  // Set the initial time in seconds
    private float currentTime;

    public PlayerAttack playerAttack;       // Reference to the PlayerAttack script
    public DinoRunAway dinoRunAwayScript;   // Reference to the DinoRunAway script

    void Start()
    {
        // Set the initial time
        currentTime = initialTime;
    }

    void Update()
    {
        // Check if the timer is above 0 and the player attack is active
        if (currentTime > 0f && IsPlayerAttackActive())
        {
            // Count down the timer
            currentTime -= Time.deltaTime;

            // You can perform actions or update UI based on the current time if needed
            // For example, update a UI text to display the remaining time
            // uiText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
        }
        else if (currentTime <= 0f)
        {
            // The timer has reached 0, perform any actions needed when time is up
            Debug.Log("Time's up!");

            // Stop the PlayerAttack script
            if (playerAttack != null)
            {
                playerAttack.StopAttack();
            }

            // Stop the DinoRunAway script
            if (dinoRunAwayScript != null)
            {
                dinoRunAwayScript.enabled = false;
            }
        }
    }

    bool IsPlayerAttackActive()
    {
        // Check if the PlayerAttack script is active
        return playerAttack != null && playerAttack.IsAttacking();
    }
}
