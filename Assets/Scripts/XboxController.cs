using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxController : MonoBehaviour
{

    //left trigger
    public static float leftTrigger
    {
       
        get
        {
            float returnValue = 0.0f;
            #if !UNITY_ANDROID || UNITY_EDITOR
                    returnValue =  Input.GetAxis("Left Trigger windows");
            #else
                    returnValue =  Input.GetAxis("Left Trigger");
            #endif
            Debug.Log("leftTrigger: "+ returnValue);
            return returnValue;
        }
    }

    //Right trigger
    public static float rightTrigger
    {

        get
        {
            float returnValue = 0.0f;
            #if !UNITY_ANDROID || UNITY_EDITOR
                returnValue = Input.GetAxis("Right Trigger windows");
            #else
                returnValue =  Input.GetAxis("Right Trigger");
            #endif
            Debug.Log("rightTrigger: " + returnValue);
            return returnValue;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
