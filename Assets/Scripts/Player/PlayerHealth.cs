using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public HealthBar healthBar; // Reference to a UI health bar

    protected override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(currentHealth);
        Debug.Log("Player Health: " + currentHealth);
    }

    protected override void Die()
    {
        // Handle player death (e.g., restart level, show game over screen)
        Debug.Log("Player Died");
        // You can add more logic here for player death
        Destroy(gameObject);
    }
}
