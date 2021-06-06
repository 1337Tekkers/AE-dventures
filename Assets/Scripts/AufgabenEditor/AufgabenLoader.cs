using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
public class AufgabenLoader : MonoBehaviour
{
    QuizAufgabe aufgabe;
    List<QuizAufgabe> aufgaben = new List<QuizAufgabe>();
    List<string> fragen = new List<string>();
    AufgabenListeHelper aufgabenListeHelper;

    public GameObject textContainer;

    private GameObject newObject;
    public Text newText;

    public Vector3 position = new Vector3(12, -4, 0);

    public Vector2 size = new Vector2(1287.896f, 2580.675f);

    public static QuizAufgabe AufgabeLaden(string path)
    {
        return JsonConvert.DeserializeObject<QuizAufgabe>(File.ReadAllText(path));
    }

    public List<QuizAufgabe> AlleAufgaben()
    {
        string[] AufgabenDateien = Directory.GetFiles(Application.persistentDataPath + "/Aufgaben/");
        foreach (var datei in AufgabenDateien)
        {
            aufgabe = AufgabeLaden(datei);
            int startIndex = datei.IndexOf("/Aufgaben/");
            string id = datei.Substring(startIndex + 10, 36);
            aufgabe.ID = id;
            aufgaben.Add(aufgabe);
            Debug.Log(id);
        }
        return aufgaben;
    }

    void Start()
    {
        Debug.Log("start");
        textContainer = GameObject.Find("TextContainer");
        aufgabenListeHelper = new AufgabenListeHelper();
        fragen = aufgabenListeHelper.getAufgabenStellungen();
        createObjects(fragen);
    }

    void createObjects(List<string> list)
    {
        int index = 0;
        foreach (var item in list)
        {
            newObject = new GameObject("Aufgabe " + index);
            newObject.transform.parent = textContainer.transform;
            newObject.transform.localScale = new Vector3(1, 1, 1);
            newObject.transform.localPosition = position;
            newText = newObject.AddComponent<Text>();
            newText.fontSize = 20;
            newText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            newText.color = Color.black;
            newText.text = item;
            newObject.GetComponent<RectTransform>().sizeDelta = size;
            position.Set(position.x, position.y - 20, 0);
            index ++;
        }

    }

}
