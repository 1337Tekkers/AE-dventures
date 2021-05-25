using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;

public class AufgabenEditor : MonoBehaviour
{
    private string frage;
    private ESchwierigkeitsgrad schwierigkeitsgrad;
    private string antwort1;
    private string antwort2;
    private string antwort3;
    private string antwort4;
    private string antwort5;
    private bool richtig1;
    private bool richtig2;
    private bool richtig3;
    private bool richtig4;
    private bool richtig5;


    // Start is called before the first frame update
    void Start()
    {
        richtig1 = true;
        schwierigkeitsgrad = ESchwierigkeitsgrad.EINFACH;

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setFrage(string input)
    {
        frage = input;
    }

    public void setAntwort1(string input)
    {
        antwort1 = input;
    }

    public void setAntwort2(string input)
    {
        antwort2 = input;
    }

    public void setAntwort3(string input)
    {
        antwort3 = input;
    }

    public void setAntwort4(string input)
    {
        antwort4 = input;
    }

    public void setAntwort5(string input)
    {
        antwort5 = input;
    }

    public void setRichtig1(bool input)
    {
        richtig1 = input;
    }

    public void setRichtig2(bool input)
    {
        richtig2 = input;
    }

    public void setRichtig3(bool input)
    {
        richtig3 = input;
    }

    public void setRichtig4(bool input)
    {
        richtig4 = input;
    }

    public void setRichtig5(bool input)
    {
        richtig5 = input;
    }

    public void SetSchwierigkeitsgradEinfach(bool input)
    {
        if (input)
        schwierigkeitsgrad = ESchwierigkeitsgrad.EINFACH;
    }

    public void SetSchwierigkeitsgradMittel(bool input)
    {
        if (input)
        schwierigkeitsgrad = ESchwierigkeitsgrad.MITTEL;
    }

    public void SetSchwierigkeitsgradSchwierig(bool input)
    {
        if (input)
        schwierigkeitsgrad = ESchwierigkeitsgrad.SCHWIERIG;
    }


    public void Hello()
    {
        QuizAufgabe quizAufgabe = new QuizAufgabe();
        quizAufgabe.SetFrage(frage);
        quizAufgabe.SetSchwierigkeitsgrad(schwierigkeitsgrad);
        quizAufgabe.SetTags(new string[] { "Test" });
        quizAufgabe.AddAntwort(new QuizAufgabe.Antwort(richtig1, antwort1));
        quizAufgabe.AddAntwort(new QuizAufgabe.Antwort(richtig2, antwort2));
        quizAufgabe.AddAntwort(new QuizAufgabe.Antwort(richtig3, antwort3));
        quizAufgabe.AddAntwort(new QuizAufgabe.Antwort(richtig4, antwort4));
        quizAufgabe.AddAntwort(new QuizAufgabe.Antwort(richtig5, antwort5));

        Debug.Log(quizAufgabe.GetFrage());

        AufgabeSpeichern(quizAufgabe);

        Debug.Log(Application.persistentDataPath);
    }

    public void AufgabeSpeichern(QuizAufgabe quizAufgabe)
    {

        string json = JsonConvert.SerializeObject(quizAufgabe);
        Debug.Log(json);

        string id = Guid.NewGuid().ToString();

        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + id + ".KWESTION";
        File.WriteAllText(jsonSavePath, json);
    }

    public static IAufgabe<string[], string> AufgabeLaden(string path)
    {
        return JsonConvert.DeserializeObject<QuizAufgabe>(File.ReadAllText(path));
    }

    public static List<string> AlleAufgaben()
    {
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
