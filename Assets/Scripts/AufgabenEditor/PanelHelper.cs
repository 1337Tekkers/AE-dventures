using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHelper : MonoBehaviour
{
    public GameObject panel;


    public void openPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void closePanel()
    {
        if (panel != null) 
        {
            panel.SetActive(false);
        }
    }
}
