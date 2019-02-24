using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CarouselAnchorDistanceManager : MonoBehaviour
{
    private float currentAnchorDistance;
    public float anchorDistanceFromPivot = 500;
    private float newDistance;
    public Transform[] anchorTransforms;

    //0 = +z
    //1 = +x
    //2 = -z
    //3 = -x

    void Update()
    {
        if(currentAnchorDistance != anchorDistanceFromPivot)
        {
            currentAnchorDistance = anchorDistanceFromPivot;

            SetNewAnchorPositions();

        }
    }

    void SetNewAnchorPositions()
    {
        anchorTransforms[0].localPosition = new Vector3(0, 0, currentAnchorDistance);
        anchorTransforms[1].localPosition = new Vector3(currentAnchorDistance, 0, 0);
        anchorTransforms[2].localPosition = new Vector3(0, 0, -currentAnchorDistance);
        anchorTransforms[3].localPosition = new Vector3(-currentAnchorDistance, 0, 0);
    }

}
