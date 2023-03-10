using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Tags.
    private readonly string safespace = "Safespace";
    //private readonly string wall = "Wall";

    private static int health = 3;
    public static int Health
    { 
        get { return health; } 
        set { health = value; } 
    }

    private float Speed { get; set; }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(safespace))
        {
            var safespace = GetComponent<Transform>();
            Physics2D.IgnoreCollision(safespace.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
