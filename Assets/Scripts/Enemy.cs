using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Tags.
    private readonly string player = "Player";

    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private int health;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }

    private void MoveEnemy()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
        {
            PlayerManager.Health -= damage;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        //Doesn't work as intended.
        Score.IncreaseScore();
    }
}
