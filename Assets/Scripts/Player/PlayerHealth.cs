using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar; // Reference to a UI health bar

    private float targetTime = 0.0f;
    private SpriteRenderer sr;

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (targetTime > 0f)
        {
            targetTime -= Time.deltaTime;
        }
        else if (targetTime <= 0.0f && sr.color != Color.white)
        {
            sr.color = Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        targetTime += 0.15f;
        sr.color = Color.red;
        healthBar.SetHealth(currentHealth);

        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death (e.g., restart level, show game over screen)
        Debug.Log("Player Died");
        // You can add more logic here for player death
        Destroy(gameObject);
    }
}
