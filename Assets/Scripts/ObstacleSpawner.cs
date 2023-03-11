using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject obstacleSpawner;

    [SerializeField] private float minSeconds = 0.5f;
    [SerializeField] private float maxSeconds = 1.5f;

    private readonly float[] yPos = { -1.5f, 0 ,1.5f };

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0);
            Instantiate(obstacles[Random.Range(0, obstacles.Length)], obstacleSpawner.transform.position + offset, obstacleSpawner.transform.rotation);
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
        }
    }
}
