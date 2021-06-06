using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AufgabenListeHelper : IObserver<string>
{
    public List<QuizAufgabe> aufgabenListe;
    List<string> aufgabenStellungen = new List<string>();
    AufgabenLoader aufgabenLoader;

    public void Notify(string message) => aufgabenStellungen.Add(message);
    // Start is called before the first frame update
    public List<string> getAufgabenStellungen()
    {
        this.aufgabenLoader = new AufgabenLoader();
        aufgabenListe = aufgabenLoader.AlleAufgaben();


        foreach (var aufgabe in aufgabenListe)
        {
            aufgabe.frage.Subscribe(this);
        }

        foreach (var aufgabenStellung in aufgabenStellungen)
        {
            Debug.Log(aufgabenStellung);
        }

        return aufgabenStellungen;
    }

}
