using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class AufgabenLoader : IObserver<string>
{
    QuizAufgabe aufgabe;
    List<string> aufgaben = new List<string>();

    public static QuizAufgabe AufgabeLaden(string path)
    {
        return JsonConvert.DeserializeObject<QuizAufgabe>(File.ReadAllText(path));
    }

    public void Notify(string message) => aufgaben.Add(message);

    public List<string> AlleAufgaben()
    {
        string[] AufgabenDateien = Directory.GetFiles(Application.persistentDataPath + "/Aufgaben/");
        foreach (var datei in AufgabenDateien)
        {
            aufgabe = (QuizAufgabe)AufgabeLaden(datei);
            aufgabe.frage.Subscribe(this);
        }
        return aufgaben;
    }
}
