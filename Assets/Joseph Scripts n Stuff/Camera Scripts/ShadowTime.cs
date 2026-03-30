using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTime : MonoBehaviour
{
    public bool ShadowGo = false;

    public CameraSwap camSwap;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ShadowGo == false)

        {
            StartCoroutine(swappin());

            //ShadowGo = true;
            camSwap.hasMoved = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && ShadowGo == true)

        {

            StartCoroutine(swapBack());

            ShadowGo = false;
            camSwap.hasMoved = false;
        }

 


    }

    public IEnumerator swappin()
    {

        yield return new WaitForSeconds(0.1f);
        if (ShadowGo == false)
        {
            ShadowGo = true;
        }


    }

    public IEnumerator swapBack() 
    {
        yield return new WaitForSeconds(0.1f);
        if (ShadowGo == true) 
        {
            ShadowGo = false;
        }
    }
}
