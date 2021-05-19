using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Color green;
    private SpriteRenderer spriteRenderer;
    private bool isCollected = false;

    public GameObject[] items;
    public GameObject spawner;
    public bool hasSpawner;

    // Start is called before the first frame update
    void Start()
    {
        green = Color.green;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = green;
        

        if (!isCollected)
        {
            foreach (GameObject item in items)
            {
                item.SetActive(true);
            }

            isCollected = true;
        }

        if (hasSpawner)
        {
            Destroy(spawner);
        }
    }
}
