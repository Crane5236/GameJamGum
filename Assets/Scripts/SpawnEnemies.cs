using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Enemy[] enemies;
    public GameObject[] doors;
    private BoxCollider2D trigger;

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
    }
}
