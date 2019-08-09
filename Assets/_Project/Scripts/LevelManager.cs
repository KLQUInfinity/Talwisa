using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Fallen Objects")]
    [SerializeField] private GameObject[] fallenPrefabs;
    [SerializeField] private float startSpawnDelay;
    private float changeSpawnDelay = 0.1f;
    private float xAxisStart, xAxisEnd;
    private float yAxis;

    [HideInInspector] public bool isPlaying;

    private void Start()
    {
        isPlaying = true;
        yAxis = Camera.main.orthographicSize + 2.0f;
        xAxisEnd = (yAxis - 3) * Camera.main.aspect;
        xAxisStart = xAxisEnd * -1;
        StartCoroutine(RandomSpawn());
    }

    IEnumerator RandomSpawn()
    {
        Vector3 pos;
        yield return new WaitForSeconds(startSpawnDelay);
        while (isPlaying)
        {
            pos = new Vector3(Random.Range(xAxisStart, xAxisEnd), yAxis);
            Instantiate(fallenPrefabs[Random.Range(0, fallenPrefabs.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(startSpawnDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ability"))
        {

        }
        else if (collision.tag.Equals("GoodThing"))
        {

        }
        else if (collision.tag.Equals("BadThing"))
        {

        }
        Destroy(collision.gameObject);
    }
}
