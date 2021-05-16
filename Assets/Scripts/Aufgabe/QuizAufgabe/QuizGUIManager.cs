using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizGUIManager : MonoBehaviour
{
    public Text frage;
    public Text[] antwort = new Text[5];

    private FrageUpdater FrageUpdaterInstance;

    private void Start()
    {
         FrageUpdaterInstance = new FrageUpdater(this);
    }

    private void SetFrage(string frage) => this.frage.text = frage;
    private void SetAntwort(string antwort, int id) => this.antwort[id].text = antwort;
    public void ZeigeNeueFrage(QuizAufgabe quizAufgabe) => FrageUpdaterInstance.ZeigeNeueFrage(quizAufgabe);

    private class FrageUpdater: IObserver<string>
    {
        QuizGUIManager manager;

        public FrageUpdater(QuizGUIManager manager)
        {
            this.manager = manager;
        }

        public void Notify(string message) => manager.SetFrage(message);

        internal void ZeigeNeueFrage(QuizAufgabe neueAufgabe)
        {
            neueAufgabe.SubscribeZuFrage(this);
        }
    }
}
