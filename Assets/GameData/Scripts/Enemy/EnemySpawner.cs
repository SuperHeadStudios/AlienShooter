using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int totalEnemies = 25;
    [SerializeField] private float spawnDistance = 40f;
    [SerializeField] private float timeGap = 10f;
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private Transform enemyParent;
    private int enemiesPerBatch = 10;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            float angle = i * Mathf.PI * 2 / totalEnemies;
            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnDistance;
            
            spawnPosition += targetPlayer.position;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, enemyParent);
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

            if (agent != null)
            {
                agent.Warp(spawnPosition);
            }

            if ((i + 1) % enemiesPerBatch == 0)
            {
                yield return new WaitForSeconds(timeGap);
            }
        }
    }
}
