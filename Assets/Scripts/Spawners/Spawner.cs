using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] entityPrefab;
    [SerializeField] private GameObject entitySpawner;

    [SerializeField] private float minDelaySec;
    [SerializeField] private float maxDelaySec;

    [SerializeField] private float activationDelay;

    [SerializeField] private float[] yPos;

    public virtual void Start()
    {
        StartCoroutine(SpawnEntities(activationDelay));
    }

    public virtual IEnumerator SpawnEntities(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            var offset = new Vector3(0, yPos[Random.Range(0, yPos.Length)], 0f);
            Instantiate(entityPrefab[Random.Range(0, entityPrefab.Length)], entitySpawner.transform.position + offset, entitySpawner.transform.rotation);
            yield return new WaitForSeconds(Random.Range(minDelaySec, maxDelaySec));
        }
    }
}