using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class TagLoader : IObserver<string>
{
    QuizAufgabe aufgabe;
    List<string> tags = new List<string>();

    public void Notify(string message) => tags.Add(message);
    
    public List<string> alleTags()
    {
        string[] AufgabenDateien = Directory.GetFiles(Application.persistentDataPath + "/Aufgaben/");

        foreach (var datei in AufgabenDateien)
        {
            aufgabe = AufgabenLoader.AufgabeLaden(datei);
            aufgabe.tag.Subscribe(this);
        }
        return tags;
    }
}
