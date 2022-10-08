using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    //public Transform spawnPoints;
    public GameObject enemyPrefab;

    public float enemySpawnInterval = 4f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(beeSpawnInterval, bee));
        SpawnNewEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= enemySpawnInterval)
        {
            SpawnNewEnemy();
            timer = 0;
        }
    }

    private void SpawnNewEnemy()
    {
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
