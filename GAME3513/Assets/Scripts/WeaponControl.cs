using System.Collections;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLifeSpan = 5f;
    public float speed = 250f;

    private float shootCooldown = 1.0f;
    private bool canShoot = true;

    // Audio handling
    private float audioResetTime = 5.0f; // 5 seconds of inactivity before switching back
    private Coroutine audioResetCoroutine;

    private AudioManager audioManager;
    private bool isFightMusicPlaying = false; // Track if fight music is already playing

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            audioManager.PlayDefault(); // Start default music at game start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            FireProjectile();
            audioManager.PlayGunShot();

            // Only play fight music if it's not already playing
            if (!isFightMusicPlaying)
            {
                audioManager.PlayFight();
                isFightMusicPlaying = true;
            }

            // Reset the audio reset timer
            if (audioResetCoroutine != null)
            {
                StopCoroutine(audioResetCoroutine);
            }
            audioResetCoroutine = StartCoroutine(AudioResetTimer());
        }
    }

    public void FireProjectile()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, spawnRotation);

        // Set velocity if projectile has a movement script
        ProjectileMovement movement = projectile.GetComponent<ProjectileMovement>();
        if (movement != null)
        {
            movement.SetVelocity(speed);
        }

        Destroy(projectile, projectileLifeSpan);

        canShoot = false;
        StartCoroutine(FireCooldown());
    }

    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    private IEnumerator AudioResetTimer()
    {
        yield return new WaitForSeconds(audioResetTime);

        // Switch back to default track only if no new shots have been fired
        audioManager.PlayDefault();
        isFightMusicPlaying = false;
    }
}
