using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    [SerializeField] private float maxHeight = 4.5f;
    [SerializeField] private float minHeight = -4.5f;
    
    // private float movementY;

    private PlayerInput playerInput;

    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (transform.position.y >= minHeight && transform.position.y <= maxHeight)
            transform.position += moveForce * Time.deltaTime * new Vector3(0f, playerInput.Vertical, 0f);

        if (transform.position.y <= minHeight)
            transform.position = new Vector3(0f, minHeight, 0f);
        if (transform.position.y >= maxHeight)
            transform.position = new Vector3(0f, maxHeight, 0f);
    }
}
