using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTime : MonoBehaviour
{
    public bool ShadowGo = false;

    public CameraSwap camSwap;


    public void Update()
    {
        if (Input.GetKey(KeyCode.P) && ShadowGo == false)

        {
            ShadowGo = true;
            camSwap.hasMoved = false;
        }

        if (Input.GetKey(KeyCode.Q) && ShadowGo == true)

        {

            ShadowGo = false;
            camSwap.hasMoved = false;
        }


    }
}
