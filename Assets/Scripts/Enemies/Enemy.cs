using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyDamage = 10;

    public float moveSpeed = 3f;
    private Transform player;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player != null) {
            Vector2 direction = (player.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // make damage to Player
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                InvokeRepeating("MakeDamageToPlayer",0.0f,0.8f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision){ // make damage while in range
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("MakeDamageToPlayer");
        }
    }

    void MakeDamageToPlayer() // stop making damage when out of range
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(EnemyDamage);
    }
}
