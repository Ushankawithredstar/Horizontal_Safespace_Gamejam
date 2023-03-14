using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    /*
    * DOESN'T WORK AS INTENDED. 
    * UNUSED.
    */
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject platformSpawner;

    [SerializeField] private int minPlatforms;
    [SerializeField] private int maxPlatforms;

    [SerializeField] private float[] yPos = {2f, -2f};

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
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        yield return new WaitForSeconds(delayTime);
        for (int i = 0; i <= platformsToSpawn; i++)
        {
            platformsSpawned++;
            var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0);
            Instantiate(platformPrefab, platformSpawner.transform.position + offset, platformSpawner.transform.rotation);
            if (platformsSpawned == platformsToSpawn)
                Roll();
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
