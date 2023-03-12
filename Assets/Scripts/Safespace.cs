using System.Collections;
using UnityEngine;

public class Safespace : MonoBehaviour
{
    //Tags.
    private readonly string player = "Player";


    [SerializeField] private int minSec;
    [SerializeField] private int maxSec;

    private readonly int playerMaxHealth = 3;

    private bool isHealing = false;
    private bool isInSafespace = false;

    private void Update()
    {
        //Health when the characters enters the "safespace".
        if (isInSafespace == true && isHealing == false && PlayerManager.Health < playerMaxHealth)
        {
            StartCoroutine(HealPlayer());
            isHealing = true;
        }
        //Stops healing when the characters leaves the "safespace".
        if (isInSafespace == false && isHealing == true || PlayerManager.Health == playerMaxHealth)
        {
            StopCoroutine(HealPlayer());
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
            isInSafespace = false;
    }

    private IEnumerator HealPlayer() 
    {
        for (int i = PlayerManager.Health; i < playerMaxHealth; i++)
        {
            PlayerManager.Health++;
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
        }
    }
}
