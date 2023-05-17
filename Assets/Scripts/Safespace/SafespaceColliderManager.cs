using System.Collections;
using UnityEngine;

public class SafespaceColliderManager : MonoBehaviour
{
    [SerializeField] private GameObject safespace;

    [SerializeField] private float waitTime = 4f;
    [SerializeField] private Collider2D collision;

    private void Awake()
    {
        collision.GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // collision.enabled = false; 
        StartCoroutine(EnableCollision());
    }

    private IEnumerator EnableCollision()
    {
        yield return new WaitForSeconds(waitTime);
        // collision.enabled = true;
    }
}