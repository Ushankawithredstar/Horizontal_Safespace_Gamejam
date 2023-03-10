using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject enemySpawner;

    [SerializeField] private float minTimeSeconds = 1.5f;
    [SerializeField] private float maxTimeSeconds = 5.5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, enemySpawner.transform.position, enemySpawner.transform.rotation);
            yield return new WaitForSeconds(Random.Range(minTimeSeconds, maxTimeSeconds));
        }
    }
}
