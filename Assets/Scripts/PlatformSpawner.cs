using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    /*
     * UNUSED.
     */

    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject platformSpawner;

    [SerializeField] private int minPlatforms;
    [SerializeField] private int maxPlatforms;

    private int platformsToSpawn;
    private int platformsSpawned;

    [SerializeField] private float delayTime;

    [SerializeField] private int minSpawnTime;
    [SerializeField] private int maxSpawnTime;

    // Start is called before the first frame update
    private void Start()
    {
        Roll();
    }

    private void Roll()
    {
        StopCoroutine(SpawnPlatforms());
        platformsToSpawn = Random.Range(minPlatforms, maxPlatforms);
        Invoke(nameof(Delay), delayTime);
    }

    private void Delay()
    {
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        for (int i = 0; i <= platformsToSpawn; i++)
        {
            platformsSpawned++;

            if (platformsSpawned == platformsToSpawn)
                Roll();

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
