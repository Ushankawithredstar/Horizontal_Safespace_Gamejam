using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameObject laserPrefab;

    public Transform entityTransform;

    public int maxHealth;
    public int damage;
    public int speed;

    public float baseDestroyTime;
    
    [HideInInspector] public int currentHealth;

    public virtual void Awake()
    {
        currentHealth = maxHealth;
        entityTransform = gameObject.GetComponent<Transform>();
    }

    public virtual void FixedUpdate()
    {
        MoveCharacter();
    }

    public virtual void MoveCharacter()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    public virtual void DestroyCharacter(float time)
    {
        Destroy (gameObject, time);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SafespaceColliderManager>(out var enemy))
        {
            var safespace = GetComponent<Transform>();
            Physics2D.IgnoreCollision(safespace.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    public virtual void Shoot()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }
}