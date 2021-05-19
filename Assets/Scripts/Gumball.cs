using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumball : MonoBehaviour
{
    public int damage = 1;
    public SpriteRenderer spriteRenderer;

    private Color orange;

    public void Start()
    {
        orange.a = 1f;
        orange.r = 1f;
        orange.g = 0.61f;
        orange.b = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();

        int number = Random.Range(0, 5);

        switch (number)
        {
            case 0:
                spriteRenderer.color = Color.red;
                break;

            case 1:
                spriteRenderer.color = Color.green;
                break;

            case 2:
                spriteRenderer.color = Color.yellow;
                break;

            case 3:
                spriteRenderer.color = Color.blue;
                break;

            case 4:
                spriteRenderer.color = orange;
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        PuzzleEnemy pEnemy = collision.gameObject.GetComponent<PuzzleEnemy>();

        if (pEnemy != null)
        {
            pEnemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

