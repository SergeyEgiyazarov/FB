using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -2.5f;
    public float columnMax = 1.2f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    //private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

    private void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }

        StartCoroutine(SpawnColumns());
    }

    private void Update()
    {
        /*timeSinceLastSpawned += Time.deltaTime;

        if (GameController.Instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }*/
    }

    private IEnumerator SpawnColumns()
    {
        while (true)
        {
            if (GameController.Instance.gameOver == false)
            {
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentColumn++;
                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
                yield return new WaitForSeconds(spawnRate);
            }
            else
            {
                yield return null;
            }
        }
    }
}
