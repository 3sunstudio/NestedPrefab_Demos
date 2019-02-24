using UnityEngine;
using System.Collections;
 
[ExecuteAlways]
public class CameraFacingBillboard : MonoBehaviour
{
    public Camera m_Camera;
 
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {

        if(m_Camera)
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                m_Camera.transform.rotation * Vector3.up);
        }


    }
}