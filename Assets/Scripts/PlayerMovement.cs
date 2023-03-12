using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 targetPos;

    [SerializeField] private float yIncrement;

    [SerializeField] private float speed;

    //private readonly float minHeight = 5f;
    //private readonly float maxHeight = -5f;

    private int currentY = 0;
    private readonly int maxY = 3;
    private readonly int minY = -3;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //I'm not sure if I should use Time.deltaTime here.
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && currentY < maxY)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            currentY++;
        }

        else if(Input.GetKeyDown(KeyCode.S) && currentY > minY)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            currentY--;
        }
    }
}
