using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float moveForce = 1.5f;
    private readonly float baseSpeed = 1f;

    private void Start()
    {
        moveForce = baseSpeed;
    }

    private void FixedUpdate()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        transform.position += moveForce * Time.deltaTime * new Vector3(baseSpeed, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var platforms = GetComponent<Transform>();
        Physics2D.IgnoreCollision(platforms.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
