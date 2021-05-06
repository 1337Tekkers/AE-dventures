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
        string json = SerializeJSON(testKlasse);
        Debug.Log(json);

        TestKlasse klasseFromJSON = JsonUtility.FromJson<TestKlasse>(json);
        Debug.Log(klasseFromJSON.text);
        string jsonSavePath = Application.persistentDataPath + "/Aufgaben/" + 1 +".KWESTION";
        File.WriteAllText(jsonSavePath,json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string SerializeJSON(TestKlasse testKlasse)
    {
        return JsonUtility.ToJson(testKlasse);
    }
}
