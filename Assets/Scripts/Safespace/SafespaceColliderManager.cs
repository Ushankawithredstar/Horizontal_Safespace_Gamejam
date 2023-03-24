using System.Collections;
using UnityEngine;

public class SafespaceColliderManager : MonoBehaviour
{
    [SerializeField] private GameObject safespace;

    [SerializeField] private float disableTime = 4f;
    private Collider2D collision;

    private void Awake()
    {
        //Throws NullReferenceException:
        //Object reference is not set to an instance of object.
        safespace.GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Should disable the collider.
        // collision.enabled = false; 
        StartCoroutine(EnableCollision());
    }

    private IEnumerator EnableCollision()
    {
        yield return new WaitForSeconds(disableTime);
        // collision.enabled = true;
    }
}