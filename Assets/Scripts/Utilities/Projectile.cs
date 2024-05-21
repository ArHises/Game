using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 0.8f;
    public int damage = 10;

    void Start()
    {
        // Destroy the projectile after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile hits an enemy
        if (collision.CompareTag("Enemy"))
        {
            //Deal damage to the enemy
            EnemyHealth enemyH = collision.GetComponent<EnemyHealth>();
            if (enemyH != null)
            {
                enemyH.TakeDamage(damage);
            }
            //Destroy the projectile upon impact
            Destroy(gameObject);
        }
    }
}
