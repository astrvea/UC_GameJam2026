using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    public GameObject realItem;
    public GameObject itemShadow;

    public Vector3 itemPos;

    public Vector3 startShadowPosition;


    // Start is called before the first frame update

    public void Awake()
    {
        startShadowPosition = new Vector3(itemShadow.transform.position.x, itemShadow.transform.position.y, itemShadow.transform.position.z);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemPos = realItem.transform.position;

        itemShadow.transform.position = new Vector3(startShadowPosition.x, itemPos.y, itemPos.z);
        

        //itemShadow.transform.rotation = realItem.transform.rotation;    
        
    }
}
