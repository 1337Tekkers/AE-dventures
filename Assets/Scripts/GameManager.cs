using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  QuizGUIManager QuizGUIManager;
    // Start is called before the first frame update
    void Start()
    {
        StelleBeispielQuizAufgabe();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StelleBeispielQuizAufgabe()
    {
        QuizAufgabe neueAufgabe = new QuizAufgabe();
        neueAufgabe.SetFrage("Wie heiﬂt du?");
        QuizGUIManager.ZeigeNeueFrage(neueAufgabe);
    }
}
