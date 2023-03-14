using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Safespace : MonoBehaviour
{
    //Tags.
    private readonly string player = "Player";

    [SerializeField] private int minSec;
    [SerializeField] private int maxSec;

    [SerializeField] private GameObject safespaceController;

    private readonly int playerMaxHealth = 3;

    private bool isHealing = false;
    private bool isInSafespace = false;

    private void Update()
    {
        //Health when the characters enters the "safespace".
        if (isInSafespace == true && isHealing == false && PlayerManager.Health < playerMaxHealth)
        {
            StartCoroutine(HealPlayer(1f));
            isHealing = true;
        }
        //Stops healing when the characters leaves the "safespace".
        if (isInSafespace == false && isHealing == true || PlayerManager.Health == playerMaxHealth)
        {
            StopCoroutine(HealPlayer(0f));
            isHealing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
            isInSafespace = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
        {
            isInSafespace = false;
            SafespaceController.isSafespaceDisabled = true;
            StartCoroutine(DisableSafespace(4f));
        }
    }

    private IEnumerator DisableSafespace(float timer)
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(timer);
    }

    private IEnumerator HealPlayer(float delay = 0f) 
    {
        yield return new WaitForSeconds(delay);
        for (int i = PlayerManager.Health; i < playerMaxHealth; i++)
        {
            PlayerManager.Health++;
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
        }
    }
}
