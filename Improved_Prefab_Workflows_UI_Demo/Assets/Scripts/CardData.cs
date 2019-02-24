using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Card Data Asset", order = 1)]
public class CardData : ScriptableObject {
    public string profileName = "Profile Name";
    public Sprite profileIcon;
    public string descriptionText = "Description Text";
    public SkillData[] skills;
}