using UnityEngine;

public class Platform : MonoBehaviour
{

    /*
     * UNUSED.
     */
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}
