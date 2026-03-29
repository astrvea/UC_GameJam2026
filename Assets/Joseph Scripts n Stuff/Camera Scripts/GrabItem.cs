using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    public GameObject playerGrabPos;
    public GameObject item;

    public GameObject itemShadow;

    public GameObject grabbedItem;

    public bool isGrabbed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {

            isGrabbed = true;

        }

        if (isGrabbed == true) 
        {
            item.transform.position = playerGrabPos.transform.position;
        }
        
    }
}
