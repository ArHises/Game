using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    protected int maxHealth = 100;
    protected int currentHealth;

    private float coloredTime = 0.0f;
    private SpriteRenderer sr;

    protected virtual void Start()
    {
        InitializeHealth();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected virtual void Update()
    {
        if (coloredTime > 0f)
        {
            coloredTime -= Time.deltaTime;
        }
        else if (coloredTime <= 0.0f && sr.color != Color.white)
        {
            sr.color = Color.white;
        }
    }

    protected void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        coloredTime += 0.15f;
        sr.color = Color.red;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
