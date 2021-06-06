using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AufgabeManager aufgabeManager;
    public Text tagText;

    // Start is called before the first frame update
    void Start()
    {
        tagText.text = StateNameController.tagText;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
