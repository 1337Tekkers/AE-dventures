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
    public List<GameObject> buttonList;

    TagLoader tl = new TagLoader();

    // Start is called before the first frame update
    void Start()
    {
        createButtonsForTags();
    }
    
    //Dynamisches Erstellen der Buttons anhand vorhandener Tags für die Themenauswahl
    void createButtonsForTags()
    {
        int currentIndex = 0;
        List<string> totalTags;

        totalTags = tl.alleTags();

        foreach (var tag in totalTags)
        {
            GameObject button = Instantiate(buttonPrefab);
            buttonList.Add(button);
            buttonList[currentIndex].transform.SetParent(buttonPanel.transform);
            buttonList[currentIndex].GetComponent<Button>().onClick.AddListener(delegate{StartGame(tag);});
            buttonList[currentIndex].transform.GetChild(0).GetComponent<Text>().text = tag;
            currentIndex++;
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
