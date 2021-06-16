using System.Collections;
using UnityEngine;

public class DemoSpawner : MonoBehaviour {

    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector2 secondsTillNextSpawn;

    private void Start()
    {
        StartCoroutine(Spawn(Random.Range(secondsTillNextSpawn.x, secondsTillNextSpawn.y)));
    }

    public IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(objectToSpawn, transform.position, Random.rotation);
        StartCoroutine(Spawn(Random.Range(secondsTillNextSpawn.x, secondsTillNextSpawn.y)));
    }
}
