using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.numBombs++;
            player.bombCount.text = "Bombs: " + player.numBombs;

            if (player.firstBomb)
            {
                player.firstBomb = false;
                player.bombMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                player.canControl = false;
                player.rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            Destroy(gameObject);
        }
    }
}
