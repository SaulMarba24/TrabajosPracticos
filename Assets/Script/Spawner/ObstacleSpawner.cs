using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;  // Prefab del obstáculo
    [SerializeField] private Vector2 spawnAreaCenter = new Vector2(0, 0);  // Centro aproximado del área de spawn
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(3, 3);  // Tamaño del área de spawn

    [SerializeField] private float minTimeToDestroy = 3f;  // Tiempo mínimo para desaparecer
    [SerializeField] private float maxTimeToDestroy = 7f;  // Tiempo máximo para desaparecer
    [SerializeField] private float minTimeBetweenSpawns = 1f;  // Tiempo mínimo entre spawns
    [SerializeField] private float maxTimeBetweenSpawns = 3f;  // Tiempo máximo entre spawns

    private void Start()
    {
        // Iniciar el ciclo de spawn
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Generar una posición random cerca del centro
            Vector2 spawnPosition = spawnAreaCenter + new Vector2(
                Random.Range(-spawnAreaSize.x / 3, spawnAreaSize.x / 3),
                Random.Range(-spawnAreaSize.y / 3, spawnAreaSize.y / 3)
            );

            // Instanciar el obstáculo en la posición random
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Elegir un tiempo random para destruir el obstáculo
            float timeToDestroy = Random.Range(minTimeToDestroy, maxTimeToDestroy);

            // Destruir el obstáculo después de ese tiempo
            Destroy(obstacle, timeToDestroy);

            // Elegir un tiempo random para el próximo spawn
            float timeToNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);

            // Mostrar en consola información del spawn
            Debug.Log($"Obstacle spawned at {spawnPosition}, will be destroyed in {timeToDestroy} seconds, next spawn in {timeToNextSpawn} seconds.");

            // Esperar antes de spawnear el próximo obstáculo
            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }
}

