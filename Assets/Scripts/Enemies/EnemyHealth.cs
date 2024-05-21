using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int setHealth = 50;

    protected override void Start()
    {
        maxHealth = setHealth; // Set maxHealth to the specific value for this enemy
        base.Start(); // Call the base class's Start method to initialize health
    }

    protected override void Die()
    {
        // Handle enemy death (e.g., play death animation, drop loot, etc.)
        Debug.Log("Enemy Died");
        Destroy(gameObject); // Destroy the enemy game object
    }
}
