using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null && player.currentHealth < 5)
        {
            player.HealDamage(1);
            Destroy(gameObject);
        }
    }
}
