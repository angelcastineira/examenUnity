using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;

    void Start()
    {
        // No necesitas instanciar un enemigo en el Start, ya que lo harás dinámicamente cuando sea necesario.
    }

    // Función para spawnear un enemigo en una posición aleatoria
    public void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        Enemy spawnedEnemy = Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}

