using System.Collections;
using UnityEngine;

public class Safespace : MonoBehaviour
{
    //Tags.
    private readonly string player = "Player";


    [SerializeField] private int minSec;
    [SerializeField] private int maxSec;

    private readonly int playerMaxHealth = 3;

    private bool isInSafespace = false;

    private void Update()
    {
        if (isInSafespace == true)
            StartCoroutine(HealPlayer());
        if (isInSafespace == false)
            StopCoroutine(HealPlayer());
    }

    //TODO:
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

    //TODO:
    private IEnumerator HealPlayer() 
    {
        for (int i = PlayerManager.Health; i < playerMaxHealth; i++)
        {
            PlayerManager.Health++;

            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
        }
    }
}
