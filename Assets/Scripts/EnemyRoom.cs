using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : MonoBehaviour
{
    public Enemy[] enemies;
    public GameObject[] doors;
    private BoxCollider2D trigger;
    public GameObject key;
    public int numEnemies;
    public bool dropItem;

    private bool completed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(true);
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.gameObject.SetActive(true);
                Destroy(trigger);
            }
        }
    }

    private void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
        numEnemies = enemies.Length;
    }

    private void Update()
    {
        if (!completed && numEnemies <= 0)
        {
            if (dropItem)
            {
                key.SetActive(true);
            }
            
            foreach(GameObject door in doors)
            {
                door.SetActive(false);
            }

            completed = true;
        }
    }
}
