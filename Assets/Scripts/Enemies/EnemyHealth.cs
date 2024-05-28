using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int setHealth = 50;

    private float stopDuration = 0.1f;
    private Enemy enemy;

    protected override void Start()
    {
        maxHealth = setHealth; // Set maxHealth to the specific value for this enemy
        base.Start(); // Call the base class's Start method to initialize health
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(int damage)
    {
        StartCoroutine(StopEnemyForDuration(stopDuration));
        // Call the base method to retain the base functionality if needed
        base.TakeDamage(damage);
    }

    private IEnumerator StopEnemyForDuration(float duration)
    {
        enemy.SetIsMoving(false); // Stop the enemy
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        enemy.SetIsMoving(true); // Resume the enemy's movement
    }

    protected override void Die()
    {
        // Handle enemy death (e.g., play death animation, drop loot, etc.)
        Debug.Log("Enemy Died");
        Destroy(gameObject); // Destroy the enemy game object
    }
}
