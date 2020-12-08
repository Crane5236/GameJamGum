using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingGum : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.ActivateStick();
            }

            PuzzleEnemy pEnemy = collision.gameObject.GetComponent<PuzzleEnemy>();

            if (pEnemy != null)
            {
                pEnemy.ActivateStick();
            }

            Shield shield = collision.gameObject.GetComponent<Shield>();

            if (shield != null)
            {
                shield.ActivateStick();
            }

            Destroy(gameObject);
        }
    }
}
    
