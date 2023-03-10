using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 targetPos;

    [SerializeField] private float yIncrement;

    [SerializeField] private float speed;

    //private readonly float minHeight = 5f;
    //private readonly float maxHeight = -5f;

    private int currentY = 0;
    private int maxY = 3;
    private int minY = -3;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && currentY < maxY)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            currentY++;
        }

        else if(Input.GetKeyDown(KeyCode.DownArrow) && currentY > minY)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            currentY--;
        }
    }
}
