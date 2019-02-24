using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    
    [Header("Card Data")]
    public CardData cardData;
    
    //Logic
    private bool isCurrentlyFocused = false;
    private bool isCurrentlyActivated = false;

    [Header("Card Display")]
    public GameObject[] cardDisplaysToHideAndShow;
    public MedalDisplayUI medalDisplayUI;

    void Awake()
    {
        for(int i = 0; i < cardDisplaysToHideAndShow.Length; i++)
        {
            cardDisplaysToHideAndShow[i].SetActive(isCurrentlyFocused);
        }

    }

    public void SetNewCardTextState(bool newState)
    {
        isCurrentlyFocused = newState;

        for(int i = 0; i < cardDisplaysToHideAndShow.Length; i++)
        {
            cardDisplaysToHideAndShow[i].SetActive(isCurrentlyFocused);
        }
    
    }

    public void SetActivatedState(bool newState)
    {
        isCurrentlyActivated = newState;
        medalDisplayUI.UpdateActivatedVisuals(isCurrentlyActivated);

    }

}
