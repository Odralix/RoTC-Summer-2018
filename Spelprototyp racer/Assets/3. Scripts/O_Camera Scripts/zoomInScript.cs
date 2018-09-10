using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomInScript : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cam;
    public Transform newTarget;

    public void ZoomIn()
    {
        cam.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathOffset.x = -2.0f;
    }

    public void ZoomOut()
    {
        cam.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathOffset.x = 0.0f;
    }

    public void switchTarget()
    {
        cam.LookAt = newTarget;
    }



}
