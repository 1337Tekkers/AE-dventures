using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;

public class AufgabenEditor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        QuizAufgabe quizAufgabe = new QuizAufgabe();
        quizAufgabe.SetFrage("Frage 1");
        quizAufgabe.SetSchwierigkeitsgrad(ESchwierigkeitsgrad.MITTEL);
        quizAufgabe.SetTags(new string[] {"Test"});
        quizAufgabe.AddAntwort("Antwort 1", 0);
        quizAufgabe.AddAntwort("Antwort 2", 0);
        quizAufgabe.AddAntwort("Antwort 3", 0);
        quizAufgabe.AddAntwort("Antwort 4", 1);

        Debug.Log(quizAufgabe.GetFrage());

        AufgabeSpeichern(quizAufgabe);
        
        Debug.Log(Application.persistentDataPath);

        foreach (var aufgabe in AlleAufgaben())
        {
            Debug.Log(aufgabe);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void AufgabeSpeichern(QuizAufgabe quizAufgabe)
    {
        
        string json = JsonConvert.SerializeObject(quizAufgabe);
        Debug.Log(json);

        string id = Guid.NewGuid().ToString();

        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + id + ".KWESTION";
        File.WriteAllText(jsonSavePath, json);
    }

    public IAufgabe<string[], string> AufgabeLaden(string path) {
        return JsonConvert.DeserializeObject<QuizAufgabe>(File.ReadAllText(path));
    }

    public List<string> AlleAufgaben() {
        string[] AufgabenDateien = Directory.GetFiles(Application.persistentDataPath + "/Aufgaben/");
        QuizAufgabe aufgabe;
        List<string> Aufgaben = new List<string>();
        foreach (var datei in AufgabenDateien)
        {
            aufgabe = (QuizAufgabe)AufgabeLaden(datei);
            Aufgaben.Add(aufgabe.GetFrage());
        }
        return Aufgaben;
    }
}
