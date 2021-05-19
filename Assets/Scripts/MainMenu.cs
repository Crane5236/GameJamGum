using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image tutorial1, tutorial2, tutorial3, tutorial4, tutorial5;

    public void ChangeScreen(int currentScreen)
    {
        switch (currentScreen)
        {
            case 0:
                tutorial1.gameObject.SetActive(true);
                break;

            case 1:
                tutorial1.gameObject.SetActive(false);
                tutorial2.gameObject.SetActive(true);
                break;

            case 2:
                tutorial2.gameObject.SetActive(false);
                tutorial3.gameObject.SetActive(true);
                break;

            case 3:
                tutorial3.gameObject.SetActive(false);
                tutorial4.gameObject.SetActive(true);
                break;

            case 4:
                tutorial4.gameObject.SetActive(false);
                tutorial5.gameObject.SetActive(true);
                break;


            case 5:
                tutorial5.gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
