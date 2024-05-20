using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDeath();
    public event EnemyDeath OnEnemyDeath;

    // This method should be called when the enemy dies
    public void Die()
    {
        // Add your death logic here (e.g., play animation, disable GameObject, etc.)

        // Notify that this enemy is dead
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath();
        }

        Destroy(gameObject);
    }

    // Example method that triggers death
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile")) // Assuming enemies die when hit by a projectile
        {
            Die();
        }
    }
}
