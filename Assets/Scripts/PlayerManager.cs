using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Tags.
    private readonly string safespace = "Safespace";
    private readonly string obstacle = "Obstacle";
    //private readonly string wall = "Wall";

    //Getters and setters are probably unnecessary.
    private static int _health = 3;
    public static int Health
    { 
        get { return _health; } 
        set { _health = value; } 
    }

    private void Update()
    {
        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(safespace))
        {
            var safespace = GetComponent<Transform>();
            Physics2D.IgnoreCollision(safespace.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag(obstacle))
            Destroy(gameObject);
    }
}
