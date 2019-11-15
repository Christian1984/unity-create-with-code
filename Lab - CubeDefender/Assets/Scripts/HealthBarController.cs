using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private RectTransform healhtBar = null;
    [SerializeField] private Text text = null;
    [SerializeField] private bool renderGameObjectName = false;

    public void UpdateHealthBar(float currentValue, float maxValue, string gameObjectName = "")
    {
        if (healhtBar)
        {
            healhtBar.transform.localScale = new Vector3((float) currentValue / maxValue, healhtBar.transform.localScale.y, healhtBar.transform.localScale.z);
        }

        if (text)
        {
            string prefix = (renderGameObjectName && gameObjectName != "") ? (gameObjectName + ": ") : "";
            text.text = prefix + Mathf.RoundToInt(currentValue) + "/" + Mathf.RoundToInt(maxValue);
        }
    }
}
