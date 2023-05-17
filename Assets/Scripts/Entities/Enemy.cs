using UnityEngine;

public class Enemy : Entity
{    
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealthManager>(out var player))
        {
            player.TakeDamage(base.damage);
            Destroy(gameObject);
        }

        base.OnTriggerEnter2D(collision);
    }

    public override void Shoot()
    {

    }
}