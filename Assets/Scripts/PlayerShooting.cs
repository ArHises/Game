using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform firePoint; // This is where the projectile will be instantiated
    public float fireRate = 0.3f; // Time interval between shots in seconds

    private bool isFiring = false;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextFireTime)
            {
                if (!isFiring)
                {
                    StartCoroutine(FireContinuously());
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }
    }

    IEnumerator FireContinuously()
    {
        isFiring = true;
        while (isFiring && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure z is zero since we are in 2D

        Vector3 direction = (mousePosition - firePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }
}
