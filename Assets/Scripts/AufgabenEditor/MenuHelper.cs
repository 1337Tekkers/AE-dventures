using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHelper : MonoBehaviour
{

    public void neueQuizaufgabe()
    {
        SceneManager.LoadScene("NeueQuizfrage");
    }

    public void uebersichtAufagaben()
    {
        SceneManager.LoadScene("UebersichtFragen");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
