using UnityEngine;

public class Entity : MonoBehaviour
{
    //I know it's better to make all of this stuff with interfaces.
    //But I spent too much time on this and I don't want to redo it again.
    
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

    public virtual void Start()
    {
        DestroyEntity(baseDestroyTime);
    }

    public virtual void FixedUpdate()
    {
        MoveEntity();
    }

    public virtual void MoveEntity()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    public virtual void DestroyEntity(float time)
    {
        Destroy (gameObject, time);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    ///<Summary>
    ///Makes entity ignore the safespace collider.
    ///</Summary>
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SafespaceColliderManager>(out var enemy))
        {
            var safespace = GetComponent<Transform>();
            Physics2D.IgnoreCollision(safespace.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        // if (collision.TryGetComponent<PlayerMovement>(out var collider))
        //     Destroy(gameObject);
    }

    //Currently UNUSED.
    public virtual void Shoot()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }
}