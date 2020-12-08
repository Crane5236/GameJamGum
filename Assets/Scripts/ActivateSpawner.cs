using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawner : MonoBehaviour
{
    public GameObject spawner;
    public bool hasActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            if (!hasActivated)
            {
                spawner.SetActive(true);
                hasActivated = true;
            }
        }
    }
}
