using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    private int damage = 1;

    [SerializeField] private Rigidbody2D bulletBody;

    private void Start()
    {
        bulletBody.GetComponent<Rigidbody2D>();
        bulletBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);

        if (hitInfo.TryGetComponent<Enemy>(out var enemy))
            enemy.TakeDamage(damage);
    }
}
