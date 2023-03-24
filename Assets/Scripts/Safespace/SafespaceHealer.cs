using System.Collections;
using UnityEngine;

public class SafespaceHealer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float initialHealDelay;

    [SerializeField] private float minSec;
    [SerializeField] private float maxSec;

    [SerializeField] private float safespaceCooldown;

    private bool isOnCooldown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOnCooldown)
            StartCoroutine(HealPlayer());
    }

    public IEnumerator HealPlayer() 
    {
        var player = this.player.GetComponent<PlayerHealthManager>();
        yield return new WaitForSeconds(initialHealDelay);

        for (int i = player.Health; i < player.MaxHealth; i++)
        {
            player.Health++;
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        StopCoroutine(HealPlayer());
        isOnCooldown = true;
        StartCoroutine(SafespaceCooldown());
    }

    private IEnumerator SafespaceCooldown()
    {
        yield return new WaitForSeconds(safespaceCooldown);
        isOnCooldown = false;
    }
}