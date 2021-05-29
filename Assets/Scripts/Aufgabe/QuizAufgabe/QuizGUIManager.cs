using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizGUIManager : MonoBehaviour, GUIElement
{
    public Text frageText;
    public Text[] antwortText = new Text[5];

    private FrageGUIUpdater frageGUIUpdater;
    private AntwortGUIUpdater antwortGUIUpdater;

    public Canvas canvas;

    private void Start()
    {
        frageGUIUpdater = new FrageGUIUpdater(this);
        antwortGUIUpdater = new AntwortGUIUpdater(this);
    }

    private void SetFrage(string frage) => this.frageText.text = frage;
    private void SetAntwort(string antwort, int id) => this.antwortText[id].text = antwort;
    public void ZeigeNeueAufgabe(QuizAufgabe quizAufgabe) {
        frageGUIUpdater.ZeigeNeueFrage(quizAufgabe);
        antwortGUIUpdater.ZeigeNeueAntworten(quizAufgabe);
    }

    private void SetAntwort(Dictionary<int, QuizAufgabe.Antwort> antwortMap)
    {
        foreach (KeyValuePair<int, QuizAufgabe.Antwort> entry in antwortMap)
        {
            antwortText[entry.Key].text = entry.Value.ToString();
        }
    }

    public void Hide()
    {
        canvas.enabled = false;
    }

    public void Show()
    {
        canvas.enabled = true;
    }

    private class FrageGUIUpdater : IObserver<string>
    {
        QuizGUIManager manager;

        public FrageGUIUpdater(QuizGUIManager manager)
        {
            this.manager = manager;
        }

        public void Notify(string message) => manager.SetFrage(message);

        internal void ZeigeNeueFrage(QuizAufgabe neueAufgabe)
        {
            neueAufgabe.frage.Subscribe(this);
        }
    }

    private class AntwortGUIUpdater : IObserver<Dictionary<int, QuizAufgabe.Antwort>>
    {
        QuizGUIManager manager;

        public AntwortGUIUpdater(QuizGUIManager manager)
        {
            this.manager = manager;
        }

        public void Notify(Dictionary<int, QuizAufgabe.Antwort> antwortMap) => manager.SetAntwort(antwortMap);

        internal void ZeigeNeueAntworten(QuizAufgabe neueAufgabe)
        {
            neueAufgabe.antworten.Subscribe(this);
        }
    }
}
