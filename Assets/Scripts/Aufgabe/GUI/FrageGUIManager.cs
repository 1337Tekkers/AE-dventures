using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrageGUIManager : MonoBehaviour, IObserver<string>
{
    public Text textFeld;

    public void Notify(string message) => textFeld.text = message;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ZeigeNeueFrage(QuizAufgabe neueAufgabe)
    {
        neueAufgabe.SubscribeZuFrage(this);
    }
}
