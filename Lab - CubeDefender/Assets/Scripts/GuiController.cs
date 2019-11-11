using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour
{
    private Text selectedBuildText = null;
    private RectTransform timerRect = null;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectedBuild = GameObject.Find("Selected Build");

        if (selectedBuild)
        {
            selectedBuildText = selectedBuild.GetComponent<Text>();
        }

        GameObject timer = GameObject.Find("Timer");

        if (timer)
        {
            timerRect = timer.GetComponent<RectTransform>();
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

    public void UpdateTimer(float timerProgress)
    {
        if (timerRect)
        {
            float val = Mathf.Clamp(timerProgress, 0, 1);
            timerRect.localScale = new Vector3(val, timerRect.localScale.y, timerRect.localScale.z);
        }
    }
}
