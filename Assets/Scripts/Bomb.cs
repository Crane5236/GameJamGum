using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float range = 2f;

    private SpriteRenderer spriteRenderer;
    private Transform location;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        location = GetComponent<Transform>();

        StartCoroutine(Detonate());
    }

    private void DetectHit()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(location.position, range);

        foreach (Collider2D collider in objectsInRange)
        {
            Enemy enemy = collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.HitByBomb();
                continue;
            }

            PuzzleEnemy pEnemy = collider.gameObject.GetComponent<PuzzleEnemy>();

            if (pEnemy != null)
            {
                pEnemy.HitByBomb();
            }

            Player player = collider.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(2);
                continue;
            }

            BreakableWall wall = collider.GetComponent<BreakableWall>();

            if (wall != null)
            {
                wall.BlowUp();
                continue;
            }
        }
    }

    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(3f);

        spriteRenderer.enabled = false;
        DetectHit();
    }

    public void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
