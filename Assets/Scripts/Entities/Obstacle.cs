using UnityEngine;

public class Obstacle : Entity
{
    public override void TakeDamage(int damage)
    {

    }

    public override void Shoot()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealthManager>(out var player))
            Destroy(player.gameObject);
        else
            base.OnTriggerEnter2D(collision);
    }
}