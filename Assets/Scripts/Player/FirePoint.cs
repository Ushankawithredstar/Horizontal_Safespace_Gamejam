using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        GetComponent<PlayerInput>().OnFire += HandleFire;
    }

    private void HandleFire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}