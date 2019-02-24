using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class MedalDisplayUI : MonoBehaviour
{

    [Header("Settings")]
    public bool enableAlphaFading = false;

    private Transform fadePointTransform;

    private float distanceFromFadePoint;

    private float fadeDistanceMultiplier;

    [Header("Visuals")]
    public Image[] medalImages;
    public Animator medalAnimator;
    public ParticleSystem activateBurstParticleSystem;
    public ParticleSystem activateContinuousParticleSystem;

    void OnEnable()
    {
        fadePointTransform = MedalGlobalFadeController.Instance.fadeReferenceTransform;
    }

    void Update()
    {

        if(enableAlphaFading)
        {
            if(fadePointTransform)
            {

                //Update If Global Alpha Changes
                if(fadeDistanceMultiplier != MedalGlobalFadeController.Instance.fadeMultiplierValue)
                {
                    fadeDistanceMultiplier = MedalGlobalFadeController.Instance.fadeMultiplierValue;
                    UpdateAllMedalImageAlphas();
                }
            

                //Update If Position Changes
                float currentDistance = Vector3.Distance(fadePointTransform.position, transform.position);
                
                if(currentDistance != distanceFromFadePoint)
                {
                    distanceFromFadePoint = currentDistance;
                    UpdateAllMedalImageAlphas();
                }
            }
        }

    }
    
    void UpdateAllMedalImageAlphas()
    {   

        float newAlphaValue = distanceFromFadePoint / fadeDistanceMultiplier;

        for(int i = 0; i < medalImages.Length; i++)
        {
            var currentMedalImageColor = medalImages[i].color;
            currentMedalImageColor.a = 1 - newAlphaValue;
            medalImages[i].color = currentMedalImageColor;    
        }
    }

    
    public void UpdateActivatedVisuals(bool newActivatedState)
    {

	if(newActivatedState == true)
	{
        activateBurstParticleSystem.Play();
        activateContinuousParticleSystem.Play();
		medalAnimator.SetTrigger("Activating");

	} else if(newActivatedState == false)
	{
        activateContinuousParticleSystem.Stop();
		medalAnimator.SetTrigger("Deactivating");
	}
	
            
    }
    

}
