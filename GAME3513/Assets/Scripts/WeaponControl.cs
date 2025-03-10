using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLifeSpan = 5f;
    public float speed = 250f;

    private float shootCooldown = 1.0f;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FireProjectile()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, spawnRotation);

        // Get the ProjectileMovement script and set speed
        ProjectileMovement movement = projectile.GetComponent<ProjectileMovement>();
        if (movement != null)
        {
            movement.SetVelocity(speed);
        }

        // Destroy after projectileLifeSpan seconds
        Destroy(projectile, projectileLifeSpan);

        canShoot = false;
        StartCoroutine(FireCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            FireProjectile();
            StartCoroutine(FireCooldown());
        }
    }

    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

}
