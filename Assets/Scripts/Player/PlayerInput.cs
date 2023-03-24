using System;
using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Vertical { get; private set; }
    public bool FireWeapons { get; private set; }

    public event Action OnFire = delegate {};

    private bool isOnCooldown = false;
    
    [SerializeField] private float shootCooldownTime = 0.25f;

    private void FixedUpdate() 
    {
        Vertical = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        FireWeapons = Input.GetButtonDown("Fire1");
        
        if (FireWeapons && !isOnCooldown)
        {
            OnFire();
            isOnCooldown = true;
            StartCoroutine(ShootCD());
        }
    }

    private IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(shootCooldownTime);
        isOnCooldown = false;
    }

}