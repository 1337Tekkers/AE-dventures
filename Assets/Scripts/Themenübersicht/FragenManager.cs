using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FragenManager : MonoBehaviour
{
    //Static zum Übergeben der Variable über Szenen hinweg
    private static string tagText;

    public Transform buttonPanel;
    public GameObject buttonPrefab;

    TagLoader tl = new TagLoader();

    // Start is called before the first frame update
    void Start()
    {
        createButtonsForTags();
    }
    
    //Dynamisches Erstellen der Buttons anhand vorhandener Tags für die Themenauswahl
    void createButtonsForTags()
    {
        List<string> totalTags;

        totalTags = tl.alleTags();

        foreach (var tag in totalTags)
        {
            tagText = tag;
            GameObject button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform);
            button.GetComponent<Button>().onClick.AddListener(delegate{StartGame(tagText);});
            button.transform.GetChild(0).GetComponent<Text>().text = tagText;
        }
    }

    //Klick auf das jeweilige Tag übergibt die Information über das Tag an den GameManager, welcher die Info an die Hauptszene weitergibt
    //Spiel wird mit dem jeweiligen Tag gestartet
    void StartGame(string input)
    {
        StateNameController.tagText = input;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
