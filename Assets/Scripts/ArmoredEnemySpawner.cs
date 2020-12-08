using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredEnemySpawner : MonoBehaviour
{
    public PuzzleEnemy armoredEnemyPrefab;
    public bool enemyAlive = false;

    public Transform location;

    public void Start()
    {
        Instantiate(armoredEnemyPrefab, location.position, Quaternion.identity);
    }

    public void SpawnEnemies()
    {
        if (location != null)
        {
            Instantiate(armoredEnemyPrefab, location.position, Quaternion.identity);
        }
    }
}
