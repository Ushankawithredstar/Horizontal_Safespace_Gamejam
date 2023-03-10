using System;
using System.Collections;
using UnityEngine;

public class Safespace : MonoBehaviour
{
    //Tags.
    private readonly string player = "Player";


    [SerializeField] private int minSec;
    [SerializeField] private int maxSec;

    private readonly int playerMaxHealh = 3;

    //TODO.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
        {
            StartCoroutine(HealPlayer());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
        {
            StopCoroutine(HealPlayer());
        }
    }

    private IEnumerator HealPlayer() 
    {
        for (int i = PlayerManager.Health; i <= playerMaxHealh; i++)
        {
            PlayerManager.Health++;
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSec, maxSec));
        }
    }
}
