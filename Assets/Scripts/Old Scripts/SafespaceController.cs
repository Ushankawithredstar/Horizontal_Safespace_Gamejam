using System.Collections;
using UnityEngine;

public class SafespaceController : MonoBehaviour
{
    public static bool isSafespaceDisabled = false;

    [SerializeField] private float delayTime = 4f;
    [SerializeField] private GameObject safespace;

    private void Update()
    {
        if (isSafespaceDisabled)
            StartCoroutine(EnableSafespace(delayTime));
    }

    public IEnumerator EnableSafespace(float timer)
    {
        yield return new WaitForSeconds(timer);
        isSafespaceDisabled = false;
        safespace.gameObject.SetActive(true);
    }
}
