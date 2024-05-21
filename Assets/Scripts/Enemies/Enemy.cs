using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyDamage = 10;

    public float moveSpeed = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Projectile projectile = collision.GetComponent<Projectile>();
            EnemyHealth EnemyHealth = GetComponent<EnemyHealth>();
            if (projectile != null)
            {
                EnemyHealth.TakeDamage(projectile.damage);
            }
        }

        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(EnemyDamage);
            }
        }
    }
}
