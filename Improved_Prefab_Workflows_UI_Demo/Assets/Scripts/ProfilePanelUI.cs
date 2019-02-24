using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfilePanelUI : MonoBehaviour
{
    [Header("UI Displays")]
    public TextMeshProUGUI profileDisplayName;
    public Image profileDisplayIcon;
    public TextMeshProUGUI profileDescriptionText;
    public SkillDisplayUI[] skillDisplays;

    public void SetNewCardData(string newProfileName, Sprite newProfileIcon, string newDescriptionText, SkillData[] newSkillData)
    {
        profileDisplayName.text = newProfileName;
        profileDisplayIcon.sprite = newProfileIcon;
        profileDescriptionText.text = newDescriptionText;

        for(int i = 0; i < skillDisplays.Length; i++)
        {
            skillDisplays[i].SetNewSkillDisplayData(newSkillData[i]);
        }
    }



}
