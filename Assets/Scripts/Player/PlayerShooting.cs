using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float nextFireTime;
    public Vector2 fireDirection;
    private bool isFiring = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
            isFiring = true;
        } else isFiring = false;
    }

    void Shoot()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        fireDirection = (mousePosition - (Vector2)firePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = fireDirection * projectile.GetComponent<Projectile>().speed;

        // Ignore collision between the player and the projectile
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    public bool getIsFiring()
    {
        return isFiring;
    }
}