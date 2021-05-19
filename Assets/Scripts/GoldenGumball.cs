using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenGumball : MonoBehaviour
{
    public Image victoryScreen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            victoryScreen.gameObject.SetActive(true);
        }
    }
}
