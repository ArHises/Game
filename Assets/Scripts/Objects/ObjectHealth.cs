using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : Health
{
    public int setHealth = 30;

    // Start is called before the first frame update
    protected override void Start()
    {
        maxHealth = setHealth; // Set maxHealth to the specific value for this enemy
        base.Start(); // Call the base class's Start method to initialize health
    }
    protected override void Update()
    {
        if (coloredTime > 0f)
        {
            coloredTime -= Time.deltaTime;
        }
    }
    public override void TakeDamage(int damage)
    {
        coloredTime += 0.05f;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
