using UnityEngine;

public class PlayerBullet : Projectile
{
    public override void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.TryGetComponent<Enemy>(out var enemy))
            enemy.TakeDamage(base.damage);

        // base.OnTriggerEnter2D(hitInfo);
    }
}