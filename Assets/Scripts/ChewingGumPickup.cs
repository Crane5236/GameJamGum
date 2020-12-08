using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingGumPickup : MonoBehaviour
{
    public GameObject chewingGumPopUp;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.canSwitch = true;
            player.canControl = false;
            player.rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            chewingGumPopUp.SetActive(true);
            Destroy(gameObject);
        }
    }
}
