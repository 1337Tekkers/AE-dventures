using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufgabeManager : MonoBehaviour
{
    public QuizGUIManager QuizGUIManager;
    public GameObject[] aufgabeTriggerGO = new GameObject[10];

    private readonly AufgabeTriggerObserver aufgabeTriggerObserver;

    private class AufgabeTriggerObserver : IObserver<Object>
    {
        private AufgabeManager aufgabeManager;

        public AufgabeTriggerObserver(AufgabeManager aufgabeManager)
        {
            this.aufgabeManager = aufgabeManager;
        }

        public void Notify(Object t)
        {
            Debug.Log("Got notified");
            aufgabeManager.StelleBeispielQuizAufgabe();
        }
    }

    public AufgabeManager()
    {
        aufgabeTriggerObserver = new AufgabeTriggerObserver(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        QuizGUIManager.Hide();
        foreach (GameObject go in aufgabeTriggerGO)
        {
            go.GetComponent<AufgabeTriggerObservable>().Subscribe(aufgabeTriggerObserver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StelleBeispielQuizAufgabe();
        }
        if (Input.GetKeyDown("h"))
        {
            QuizGUIManager.Hide();
        }
        if (Input.GetKeyDown("s"))
        {
            QuizGUIManager.Show();
        }
    }

    public void StelleBeispielQuizAufgabe()
    {
        QuizAufgabe neueAufgabe = new QuizAufgabe();
        neueAufgabe.frage.Set("Wie heiﬂt du?");
        neueAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(false, "Hans"));
        neueAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(false, "Silke"));
        neueAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(false, "Peter"));
        neueAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(false, "Vladimir"));
        neueAufgabe.antworten.AddAntwort(new QuizAufgabe.Antwort(true, "Gaia"));
        QuizGUIManager.ZeigeNeueAufgabe(neueAufgabe);
        QuizGUIManager.Show();
    }
}
