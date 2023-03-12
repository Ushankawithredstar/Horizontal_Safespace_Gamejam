using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int speed;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}
