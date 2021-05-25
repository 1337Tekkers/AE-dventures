using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AufgabenListeHelper : MonoBehaviour
{
    public List<string> aufgabenListe;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        aufgabenListe = AufgabenEditor.AlleAufgaben();


        foreach (var aufgabe in aufgabenListe)
        {
            Debug.Log(aufgabe);
            text.text += aufgabe + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
