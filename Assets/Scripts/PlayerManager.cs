using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private readonly string abyss = "Abyss";
    private readonly string wall = "Wall";

    //private int health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(wall) || collision.gameObject.CompareTag(abyss))
            Destroy(gameObject);
    }
}
