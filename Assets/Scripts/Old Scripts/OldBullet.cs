using UnityEngine;

public class OldBullet : MonoBehaviour
{

    //
    //
    //  UNUSED.
    //
    //

    //Tags.
    // private string safespace = "Safespace";

    private int damage = 1;
    [SerializeField] private float speed = 30f;

    [SerializeField] private float destroyTimeSec = 4f;

    [SerializeField] private Rigidbody2D bulletBody;

    private void Awake()
    {
        bulletBody.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        bulletBody.velocity = speed * transform.right;
        Destroy(gameObject, destroyTimeSec);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.TryGetComponent<Enemy>(out var enemy))
        {
            // enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        //Ignores the "Safespace" collider.
        // if (hitInfo.gameObject.CompareTag(safespace))
        // if (hitInfo.TryGetComponent<Safespace>(out Safespace component))
        // {
        //     var safespace = GetComponent<Transform>();
        //     Physics2D.IgnoreCollision(safespace.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // }
    }
}
