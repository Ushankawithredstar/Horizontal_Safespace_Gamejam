using UnityEngine;

public class OldObstacle : MonoBehaviour
{
    //
    //
    //  UNUSED.
    //
    //

    [SerializeField] private int speed;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}
