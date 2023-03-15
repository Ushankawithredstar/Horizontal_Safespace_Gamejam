using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    /*
    * DOESN'T WORK AS INTENDED. 
    */

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject platformSpawner;

    [SerializeField] private int minPlatforms;
    [SerializeField] private int maxPlatforms;

    private int platformsToSpawn;
    private int platformsSpawned;

    [SerializeField] private float delayTime = 1f;

    [SerializeField] private int minSpawnTime;
    [SerializeField] private int maxSpawnTime;

    // Start is called before the first frame update
    private void Start()
    {
        Roll();
    }

    private void Roll()
    {
        platformsToSpawn = Random.Range(minPlatforms, maxPlatforms);
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        yield return new WaitForSeconds(delayTime);
        for (int i = 0; i <= platformsToSpawn; i++)
        {
            platformsSpawned++;
            //The line below is no longer used.
            // var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0);
            Instantiate(platformPrefab, platformSpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            if (platformsSpawned == platformsToSpawn)
                Roll();
        }
    }
}
