using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject obstacleSpawner;

    [SerializeField] private float minSeconds = 1.5f;
    [SerializeField] private float maxSeconds = 3.5f;

    [SerializeField] private float activationDelay = 4f;

    private readonly float[] yPos = { -1.5f, 0 ,1.5f };

    // Start is called before the first frame update
    private void Start()
    {
        //Activates the spawner after a delay.
        StartCoroutine(SpawnObstacles(activationDelay));
    }

    private IEnumerator SpawnObstacles(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            if (SafespaceController.isSafespaceDisabled)
            {
                var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0);
                Instantiate(enemy, obstacleSpawner.transform.position + offset, obstacleSpawner.transform.rotation);
                yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
            }
            else
            {
                var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0);
                Instantiate(obstacles[Random.Range(0, obstacles.Length)], obstacleSpawner.transform.position + offset, obstacleSpawner.transform.rotation);
                yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
            }
        }
    }
}
