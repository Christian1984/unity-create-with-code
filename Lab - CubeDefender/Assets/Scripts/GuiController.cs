using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour
{
    private Text selectedBuildText = null;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectedBuild = GameObject.Find("Selected Build");

        if (selectedBuild)
        {
            selectedBuildText = selectedBuild.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void UpdateSelectedBuildText(string name)
    {
        if (selectedBuildText)
        {
            selectedBuildText.text = "Selected Build: " + name;
        }
    }
}
