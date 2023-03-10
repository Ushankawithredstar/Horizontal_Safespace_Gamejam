using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private bool onCooldown = false;

    // Update is called once per frame
    void Update()
    {
        //shooting.
        if (Input.GetButtonDown("Fire1") && onCooldown == false)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            onCooldown = true;
            Invoke(nameof(ShootCD), 0.4f);
        }
    }

    private void ShootCD() => onCooldown = false;
}
