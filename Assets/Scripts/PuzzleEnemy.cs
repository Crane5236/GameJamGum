using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnemy : MonoBehaviour
{
    public int currentHealth = 3;
    public float moveSpeed = 3f;
    public Transform playerLocation;
    public int damage = 1;
    public GameObject chewingGum;
    public bool isArmored;
    public Sprite defaultSprite;
    public ArmoredEnemySpawner spawner;

    private bool stuck = false;
    private Color enemyDefault;
    private Color damageColor;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    private void Start()
    {
        chewingGum.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        enemyDefault.a = 1f;
        enemyDefault.r = 0.5627012f;
        enemyDefault.g = 0f;
        enemyDefault.b = 0.5660378f;

        damageColor = Color.red;
    }

    void Update()
    {
        if (!stuck)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, moveSpeed * Time.deltaTime);
            transform.right = playerLocation.position - transform.position;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isArmored)
        {
            currentHealth -= damageAmount;
            StartCoroutine(ShowDamage());
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            spawner.SpawnEnemies();
        }
    }

    IEnumerator ShowDamage()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(.25f);
        spriteRenderer.color = enemyDefault;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(damage);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }

    public void ActivateStick()
    {
        StartCoroutine(GumStick());
    }

    IEnumerator GumStick()
    {
        stuck = true;
        chewingGum.SetActive(true);

        yield return new WaitForSeconds(5f);

        stuck = false;
        chewingGum.SetActive(false);
    }

    public void DestroyArmor()
    {
        spriteRenderer.sprite = defaultSprite;
        spriteRenderer.color = enemyDefault;

        isArmored = false;
    }

    public void HitByBomb()
    {
        if (isArmored)
            DestroyArmor();
        else
            TakeDamage(2);
    }
}
