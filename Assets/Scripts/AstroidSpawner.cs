using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] astroidPrefabs;
    [SerializeField] private float secondBetweenAstroids = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float timer;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera=Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnAstroid();
            timer += secondBetweenAstroids;
        }
    }

    private void SpawnAstroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                // Left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                // Right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                // Bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                // Top
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z=0;

        GameObject selectedAstroid=astroidPrefabs[Random.Range(0,astroidPrefabs.Length)];
        GameObject astroidInstance = Instantiate(
            selectedAstroid,
            worldSpawnPoint,
            Quaternion.Euler(0f,0f,Random.Range(0f,360f)));

        Rigidbody rb = astroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x,forceRange.y);
    }
}
