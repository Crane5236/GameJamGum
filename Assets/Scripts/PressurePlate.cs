using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Color red;
    private Color green;
    private SpriteRenderer spriteRenderer;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        red = Color.red;
        green = Color.green;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = green;
        door.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = red;
        door.SetActive(true);
    }
}
