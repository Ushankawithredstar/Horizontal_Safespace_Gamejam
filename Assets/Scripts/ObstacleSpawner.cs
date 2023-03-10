using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject obstacleSpawner;

    [SerializeField] private float minSeconds = 0.3f;
    [SerializeField] private float maxSeconds = 1.5f;

    private float[] YPos = { -1.5f, 1.5f };

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Instantiate(obstacles[Random.Range(0, YPos.Length)]);
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
        }
    }
}
