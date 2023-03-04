using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float moveForce = 1.5f;
    private readonly float movementX = 1f;

    private void FixedUpdate()
    {
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var platforms = GetComponent<Transform>();
        Physics2D.IgnoreCollision(platforms.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
