using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillDisplayUI : MonoBehaviour
{

    public TextMeshProUGUI skillDisplayName;
    public Image skillDisplayIcon;

    public void SetNewSkillDisplayData(SkillData newSkillData)
    {
        skillDisplayName.text = newSkillData.skillName;
        skillDisplayIcon.sprite = newSkillData.skillIcon;
    }

}
