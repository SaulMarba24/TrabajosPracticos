using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;  // Prefab del obst�culo
    [SerializeField] private Vector2 spawnAreaCenter = new Vector2(0, 0);  // Centro aproximado del �rea de spawn
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(3, 3);  // Tama�o del �rea de spawn

    [SerializeField] private float minTimeToDestroy = 3f;  // Tiempo m�nimo para desaparecer
    [SerializeField] private float maxTimeToDestroy = 7f;  // Tiempo m�ximo para desaparecer
    [SerializeField] private float minTimeBetweenSpawns = 1f;  // Tiempo m�nimo entre spawns
    [SerializeField] private float maxTimeBetweenSpawns = 3f;  // Tiempo m�ximo entre spawns

    private void Start()
    {
        // Iniciar el ciclo de spawn
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Generar una posici�n random cerca del centro
            Vector2 spawnPosition = spawnAreaCenter + new Vector2(
                Random.Range(-spawnAreaSize.x / 3, spawnAreaSize.x / 3),
                Random.Range(-spawnAreaSize.y / 3, spawnAreaSize.y / 3)
            );

            // Instanciar el obst�culo en la posici�n random
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Elegir un tiempo random para destruir el obst�culo
            float timeToDestroy = Random.Range(minTimeToDestroy, maxTimeToDestroy);

            // Destruir el obst�culo despu�s de ese tiempo
            Destroy(obstacle, timeToDestroy);

            // Elegir un tiempo random para el pr�ximo spawn
            float timeToNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);

            // Mostrar en consola informaci�n del spawn
            Debug.Log($"Obstacle spawned at {spawnPosition}, will be destroyed in {timeToDestroy} seconds, next spawn in {timeToNextSpawn} seconds.");

            // Esperar antes de spawnear el pr�ximo obst�culo
            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }
}

