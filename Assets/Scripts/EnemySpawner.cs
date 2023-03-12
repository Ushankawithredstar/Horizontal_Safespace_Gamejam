using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly float[] yPos = { -4.5f, -3f, 3f, 4.5f };

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemySpawner;

    [SerializeField] private float minTimeSeconds = 0.3f;
    [SerializeField] private float maxTimeSeconds = 1.5f;

    [SerializeField] private float activationDelay = 1.0f;

    private void Start()
    {
        //Activates the spawner after a delay.
        StartCoroutine(SpawnEnemies(activationDelay));
    }

    private IEnumerator SpawnEnemies(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Started");
        //Chooses a random Y position from an array and spawns an enemy. 
        while (true)
        {
            var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0);
            Instantiate(enemyPrefab, enemySpawner.transform.position + offset, enemySpawner.transform.rotation);
            yield return new WaitForSeconds(Random.Range(minTimeSeconds, maxTimeSeconds));
        }
    }
}
