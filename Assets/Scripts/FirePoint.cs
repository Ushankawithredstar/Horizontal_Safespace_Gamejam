using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private bool onCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && onCooldown == false)
            Shoot();
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        onCooldown = true;
        Invoke(nameof(ShootCD), 1f);
    }

    private void ShootCD()
    {
        onCooldown = false;
    }
}
