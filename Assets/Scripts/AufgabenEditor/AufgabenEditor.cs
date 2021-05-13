using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AufgabenEditor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        TestKlasse testKlasse = new TestKlasse();
        testKlasse.text = "Test";
        testKlasse.richtig = true;
        testKlasse.antworten = new string[] {"Antwort 1", "Antwort 2", "Antwort 3"};

        AufgabeSpeichern(testKlasse);

        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + 1 + ".KWESTION";
        TestKlasse klasseFromJSON = JsonUtility.FromJson<TestKlasse>(File.ReadAllText(jsonSavePath));
        Debug.Log(klasseFromJSON.text);
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void AufgabeSpeichern(TestKlasse testKlasse)
    {
        string json = JsonUtility.ToJson(testKlasse);
        Debug.Log(json);

        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + 1 + ".KWESTION";
        File.WriteAllText(jsonSavePath, json);
    }
}
