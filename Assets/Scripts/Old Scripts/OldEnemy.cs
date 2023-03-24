using UnityEngine;

public class OldEnemy : MonoBehaviour
{

    //
    //
    //  UNUSED.
    //
    //

    //Tags.
    private string player = "Player";

    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private int health;

    [SerializeField] private float destroyTime = 4.5f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    // public void TakeDamage(int damage)
    // {
    //     health -= damage;

    //     if (health <= 0)
    //     {
    //         // GameplayUIController.ScoreCount++;
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
        {
            // PlayerHealthManager.Health -= damage;
            Destroy(gameObject);
        }
    }
}
