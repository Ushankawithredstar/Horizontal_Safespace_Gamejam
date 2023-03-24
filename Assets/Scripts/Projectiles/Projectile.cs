using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    public float speed;

    public float destroyTime;

    public Rigidbody2D rb;

    public virtual void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    } 

    public virtual void Start()
    {
        MoveProjectile();
        Destroy(gameObject, destroyTime);
    }

    public virtual void MoveProjectile()
    {
        rb.velocity = speed * transform.right;
    }

    public virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.TryGetComponent<SafespaceColliderManager>(out SafespaceColliderManager component))
        {
            var safespace = GetComponent<Transform>();
            Physics2D.IgnoreCollision(safespace.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}