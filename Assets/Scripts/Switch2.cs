using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    private Color green;
    private SpriteRenderer spriteRenderer;

    public GameObject barrier;

    // Start is called before the first frame update
    void Start()
    {
        green = Color.green;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = green;

        barrier.SetActive(false);
    }
}
