using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivatePanelUI : MonoBehaviour
{
    [Header("Settings")]
    public string activatedText = "Activated";
    public string activateText = "Activate";
    public Color normalTextColor;
    public Color transitionTextColor;


    [Header("Visuals")]
    public TextMeshProUGUI activateDisplayText;


    //0 - Activated
    //1 - Activate
    //2 - disabled (During Transition)
    public void SetNewVisuals(int newState)
    {
        switch (newState){

            case 0:
                activateDisplayText.text = activatedText;
                activateDisplayText.color = normalTextColor;
                break;

            case 1:
                activateDisplayText.text = activateText;
                activateDisplayText.color = normalTextColor;
                break;

            case 2:
                activateDisplayText.color = transitionTextColor;
                break;
        }
    }

}
