using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTime : MonoBehaviour
{
    public bool ShadowGo = false;

    public CameraSwap camSwap;

    public GameObject playerSprite;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ShadowGo == false)

        {
            StartCoroutine(swappin());

            //ShadowGo = true;
            camSwap.hasMoved = false;

            playerSprite.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Q) && ShadowGo == true)

        {

            StartCoroutine(swapBack());

            ShadowGo = false;
            camSwap.hasMoved = false;

            playerSprite.transform.rotation *= Quaternion.Euler(-30, -135, 0);
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
