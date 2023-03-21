using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    [SerializeField] private float maxHeight = 4.5f;
    [SerializeField] private float minHeight = -4.5f;
    
    private float movementY;

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (transform.position.y >= minHeight && transform.position.y <= maxHeight)
        {
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += moveForce * Time.deltaTime * new Vector3(0f, movementY, 0f);
        }

        if (transform.position.y <= minHeight)
            transform.position = new Vector3(0f, minHeight, 0f);
        else if (transform.position.y >= maxHeight)
            transform.position = new Vector3(0f, maxHeight, 0f);
    }
}
