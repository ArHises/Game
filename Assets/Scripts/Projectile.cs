using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 1f; // Time in seconds before the projectile is destroyed

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
