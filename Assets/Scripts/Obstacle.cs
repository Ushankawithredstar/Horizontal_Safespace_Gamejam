using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int speed;
 
    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

}
