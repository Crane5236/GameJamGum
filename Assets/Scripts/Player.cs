using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Camera cam;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject chewingGumPrefab;
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    public Text switchAmmoText;
    public Text bombCount;
    public Text healthCount;
    public Text keyCount;
    public Image chewingGumMenu;
    public Image bombMenu;
    public Image gameOver;
    public SpriteRenderer spriteRenderer;

    Vector2 movement;
    Vector2 mousePosition;

    public float bulletForce = 20f;
    public float fireRate = .5f;
    public float speed = 5f;
    public int currentHealth = 5;
    public float invincibilityTime = 1f;
    public bool canControl = true;
    public int keys = 0;
    public int numBombs = 0;
    public bool canSwitch = false;
    public bool firstBomb = true;

    private float nextFire;
    private float nextDamage = 0;
    private bool gumBallAmmo = true;
    private bool canPlaceBomb = true;
    private Color defaultColor;
    private Color damageColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        damageColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && canControl)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        if (Input.GetButtonDown("Ammo") && canSwitch)
        {
            if (gumBallAmmo)
            {
                gumBallAmmo = false;
                switchAmmoText.text = "Switched to Chewing Gum";
            }
            else
            {
                gumBallAmmo = true;
                switchAmmoText.text = "Switched to Gumballs";
            }

            StartCoroutine(DisplayAmmoText());
        }

        if (Input.GetButtonDown("Jump"))
        {
            PlaceBomb();
        }
    }

    IEnumerator DisplayAmmoText()
    {
        switchAmmoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        switchAmmoText.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePosition - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }

    void Shoot()
    {
        if (gumBallAmmo)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
            rb2d.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            GameObject chewingGum = Instantiate(chewingGumPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2d = chewingGum.GetComponent<Rigidbody2D>();
            rb2d.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int damage)
    {
        if (Time.time > nextDamage)
        {
            currentHealth -= damage;
            healthCount.text = "Health: " + currentHealth;
            nextDamage = Time.time + invincibilityTime;
            StartCoroutine(ShowDamage());

            if (currentHealth <= 0)
            {
                gameOver.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ShowDamage()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(.25f);
        spriteRenderer.color = defaultColor;
    }

    public void HealDamage(int heal)
    {
        currentHealth += heal;
        healthCount.text = "Health: " + currentHealth;
    }

    public void PlaceBomb()
    {
        if (numBombs > 0 && canPlaceBomb)
        {
            Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
            canPlaceBomb = false;
            numBombs--;
            bombCount.text = "Bombs: " + numBombs;
            StartCoroutine(BombTimer());
        }
    }

    IEnumerator BombTimer()
    {
        yield return new WaitForSeconds(3f);
        canPlaceBomb = true;
    }

    public void CloseChewingGum()
    {
        chewingGumMenu.gameObject.SetActive(false);
        canControl = true;
        rb2d.constraints = RigidbodyConstraints2D.None;
    }

    public void CloseBombMenu()
    {
        bombMenu.gameObject.SetActive(false);
        canControl = true;
        rb2d.constraints = RigidbodyConstraints2D.None;
        Time.timeScale = 1;
    }
}
