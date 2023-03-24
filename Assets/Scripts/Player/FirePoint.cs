using System.Collections;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float cooldownTime = 0.45f;


    private void Awake()
    {
        //Shows NullReferenceException.
        GetComponent<PlayerInput>().OnFire += HandleFire;
    }

    private void HandleFire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
