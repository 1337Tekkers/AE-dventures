using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class AufgabenEditor : MonoBehaviour
{
    private string frage;
    private ESchwierigkeitsgrad schwierigkeitsgrad;
    private string aufgabenTag;
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

    private Button saveButton;


    // Start is called before the first frame update
    void Start()
    {
        richtig1 = true;
        schwierigkeitsgrad = ESchwierigkeitsgrad.EINFACH;

        saveButton = GameObject.Find("Speichern_Button").GetComponent<Button>();
        saveButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkInputs())
        {
            saveButton.interactable = true;
        }
        else {
            saveButton.interactable = false;
        }
    }

    public bool checkInputs()
    {
        if (!String.IsNullOrEmpty(frage) 
        && !String.IsNullOrEmpty(aufgabenTag) 
        && !String.IsNullOrEmpty(antwort1) 
        && !String.IsNullOrEmpty(antwort2) 
        && !String.IsNullOrEmpty(antwort3)
        && !String.IsNullOrEmpty(antwort4)
        && !String.IsNullOrEmpty(antwort5))
        {
            return true;
        }
        return false;
    }

    public void neueAufgabe() 
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

    public void SetTag(string input)
    {
        aufgabenTag = input;
    }


    public void AufgabeErstellen()
    {
        QuizAufgabe quizAufgabe = new QuizAufgabe();
        quizAufgabe.frage.Set(frage);
        quizAufgabe.schwierigkeitsgrad.Set(schwierigkeitsgrad);
        quizAufgabe.tag.Set(aufgabenTag);
        quizAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(richtig1, antwort1));
        quizAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(richtig2, antwort2));
        quizAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(richtig3, antwort3));
        quizAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(richtig4, antwort4));
        quizAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(richtig5, antwort5));

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
}
