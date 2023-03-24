using UnityEngine;

public class EnemyProjectile : Projectile
{
    public override void MoveProjectile()
    {
        base.MoveProjectile();
    }

    public override void OnTriggerEnter2D(Collider2D hitInfo)
    {
        base.OnTriggerEnter2D(hitInfo);

        if (hitInfo.TryGetComponent<PlayerHealthManager>(out var player))
            player.TakeDamage(base.damage);
    }
}