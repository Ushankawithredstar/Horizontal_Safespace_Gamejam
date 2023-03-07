using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce = 1.5f;
    private readonly float forceJump = 11f; //Do not change.

    private Rigidbody2D rb;

    private bool isGrounded = true;
    private readonly string ground = "Ground";

    private float movementX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        PlayerJump();
    }

    private void MovePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, forceJump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ground))
            isGrounded = true;
    }
}
