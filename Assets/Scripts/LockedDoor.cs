using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if (player.keys > 0)
            {
                player.keys--;
                player.keyCount.text = "Keys: " + player.keys;
                Destroy(gameObject);
            }
        }
    }
}
