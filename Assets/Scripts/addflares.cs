using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addflares : MonoBehaviour
{
    public GameObject rightEye;
    public GameObject centerEye;
    public GameObject leftEye;

    void Start()
    {
        Invoke("addFlarez", 1f);
    }

    public void addFlarez()
    {
        //rightEye = GameObject.Find("GvrViewerMain Right");
        rightEye.AddComponent<FlareLayer>();
       // leftEye = GameObject.Find("GvrViewerMain Left");
        leftEye.AddComponent<FlareLayer>();
      //  centerEye = GameObject.Find("GvrViewerMain Center");
        centerEye.AddComponent<FlareLayer>();
    }
}