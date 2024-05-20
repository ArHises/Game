using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public float moveSpeed = 3f;
    private Transform player;

    private SpriteRenderer sr;

    private float targetTime = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;

        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f && sr.color != Color.white)
        {
            sr.color = Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        targetTime += 0.4f;
        sr.color = Color.red;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optionally play a death animation or sound here
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Projectile projectile = collision.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damage);
            }
        }

        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Assume the enemy deals 10 damage on contact
            }
        }
    }
}
