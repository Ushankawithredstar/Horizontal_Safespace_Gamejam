using UnityEngine;

public class Wall : MonoBehaviour
{
    /*
     * UNUSED.
     */


    //[SerializeField] private float moveForce = 1.5f;
    //[SerializeField] private float movementX = 1f;

    private void FixedUpdate()
    {
        //transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    private void OnCollisionEnter2D()
    {
        var platforms = GetComponent<Transform>();
        Physics2D.IgnoreCollision(platforms.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
