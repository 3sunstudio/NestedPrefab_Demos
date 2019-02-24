using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarouselController : MonoBehaviour
{

    [Header("Inputs")]
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode activateKey;

    [Header("Logic")]
    public ActivatePanelUI activatePanelUI;
    public ProfilePanelUI profilePanelUI;
    public CardBehaviour[] carouselCardBehaviours;
    private CardBehaviour currentCard;
    private int currentCardID = 0;
    private bool carouselIsMoving = false;
    private int activatedCardID;

    [Header("Carousel Movement Settings")]
    public Transform carouselRootTransform;
    public float movementDuration;

    void Start()
    {
        currentCard = carouselCardBehaviours[currentCardID];

        ActivateFirstCard();
        ShowCurrentCardTextInfo();
        SetNewCardProfilePanelUI();
    }

    void Update()
    {

        if(!carouselIsMoving)
        {
            if(Input.GetKeyDown(leftKey))
            {
                RotateCarousel(-1);
            }

            if(Input.GetKeyDown(rightKey))
            {
                RotateCarousel(1);
            }

            if(Input.GetKeyDown(activateKey))
            {
		if(activatedCardID != currentCardID)
		{
                	ActivateCurrentCard();
		}
            }
        }
    }

    void RotateCarousel(int rotationDirection)
    {

        carouselIsMoving = true;

        HideCurrentCardTextInfo();
        CalculateActivatedPanelState();


        carouselRootTransform.DORotate(new Vector3(0, 90 * rotationDirection, 0), movementDuration, RotateMode.LocalAxisAdd).SetRelative().OnComplete(()=>CarouselMovementEnded(rotationDirection));

    }

    void CarouselMovementEnded(int newCurrentCardIntDifference)
    {

        currentCardID -= newCurrentCardIntDifference;
        if(currentCardID < 0)
        {
            currentCardID = carouselCardBehaviours.Length - 1;
        } else if(currentCardID > carouselCardBehaviours.Length - 1)
        {
            currentCardID = 0;
        }

        currentCard = carouselCardBehaviours[currentCardID];

        SetNewCardProfilePanelUI();
        ShowCurrentCardTextInfo();

        carouselIsMoving = false;
        
        CalculateActivatedPanelState();

    }

    void SetNewCardProfilePanelUI()
    {        
        profilePanelUI.SetNewCardData(
            currentCard.cardData.profileName,
            currentCard.cardData.profileIcon,
            currentCard.cardData.descriptionText,
            currentCard.cardData.skills
        );
        
    }

    void ShowCurrentCardTextInfo()
    {
        currentCard.SetNewCardTextState(true);
    }

    void HideCurrentCardTextInfo()
    {
        currentCard.SetNewCardTextState(false);
    }

    void ActivateFirstCard()
	{
        activatedCardID = currentCardID;
        carouselCardBehaviours[activatedCardID].SetActivatedState(true);
        CalculateActivatedPanelState();
    }

    void ActivateCurrentCard()
    {

        carouselCardBehaviours[activatedCardID].SetActivatedState(false);
        activatedCardID = currentCardID;
        carouselCardBehaviours[activatedCardID].SetActivatedState(true);
        CalculateActivatedPanelState();
    }

    void CalculateActivatedPanelState()
    {

        if(carouselIsMoving)
        {
            activatePanelUI.SetNewVisuals(2);
            return;
        }

        if(currentCardID == activatedCardID){
            activatePanelUI.SetNewVisuals(0);
            return;
        }

        if(currentCardID != activatedCardID){
            activatePanelUI.SetNewVisuals(1);
            return;
        }
    }
   
}
