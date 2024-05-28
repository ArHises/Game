using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 0.8f;
    public int damage = 10;

    private Rigidbody2D rb;


    void Start()
    {
        // Destroy the projectile after its lifetime expires
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        Vector2 direction = rb.velocity;

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
            Debug.Log("Enemy helth: " + enemyH.getCurrentHealth());
            //Destroy the projectile upon impact
            Destroy(gameObject);
        }
        if (collision.CompareTag("Object"))
        {
            //Deal damage to the object
            ObjectHealth objectH = collision.GetComponent<ObjectHealth>();
            if (objectH != null)
            {
                objectH.TakeDamage(damage);
            }
            Debug.Log("Object helth: " + objectH.getCurrentHealth());
            //Destroy the projectile upon impact
            Destroy(gameObject);
        }
    }
}
