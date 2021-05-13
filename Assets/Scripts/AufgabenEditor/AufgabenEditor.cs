using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class AufgabenEditor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        TestKlasse testKlasse = new TestKlasse();
        testKlasse.SetFrage("Frage 1");
        testKlasse.SetSchwierigkeitsgrad(ESchwierigkeitsgrad.MITTEL);
        testKlasse.SetTags(new string[] {"Test"});
        testKlasse.AddAntwort("Antwort 1", 0);
        testKlasse.AddAntwort("Antwort 2", 0);
        testKlasse.AddAntwort("Antwort 3", 0);
        testKlasse.AddAntwort("Antwort 4", 1);

        Debug.Log(testKlasse.GetFrage());

        AufgabeSpeichern(testKlasse);
        
        Debug.Log(Application.persistentDataPath);

        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + 1 + ".KWESTION";
        TestKlasse klasseFromJSON = AufgabeLaden(jsonSavePath);

        Debug.Log(klasseFromJSON.GetFrage());
        foreach (var tag in klasseFromJSON.GetTags())
        {
            Debug.Log(tag);
        }

        foreach (var antwort in klasseFromJSON.GetAntwortOptionen())
        {
            Debug.Log(antwort);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void AufgabeSpeichern(TestKlasse testKlasse)
    {
        
        string json = JsonConvert.SerializeObject(testKlasse);
        Debug.Log(json);

        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + 1 + ".KWESTION";
        File.WriteAllText(jsonSavePath, json);
    }

    public TestKlasse AufgabeLaden(string path) {
        return JsonConvert.DeserializeObject<TestKlasse>(File.ReadAllText(path));
    }
}
