using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  QuizGUIManager QuizGUIManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StelleBeispielQuizAufgabe();
        }
    }

    void StelleBeispielQuizAufgabe()
    {
        QuizAufgabe neueAufgabe = new QuizAufgabe();
        neueAufgabe.SetFrage("Wie heiﬂt du?");
        neueAufgabe.AddAntwort(new QuizAufgabe.Antwort(false, "Hans"));
        neueAufgabe.AddAntwort(new QuizAufgabe.Antwort(false, "Silke"));
        neueAufgabe.AddAntwort(new QuizAufgabe.Antwort(false, "Peter"));
        neueAufgabe.AddAntwort(new QuizAufgabe.Antwort(false, "Vladimir"));
        neueAufgabe.AddAntwort(new QuizAufgabe.Antwort(true, "Gaia"));
        QuizGUIManager.ZeigeNeueAufgabe(neueAufgabe);
    }
}
