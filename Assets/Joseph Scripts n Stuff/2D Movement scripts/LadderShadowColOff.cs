using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderShadowColOff : MonoBehaviour
{

    public bool turnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (turnOff == true) 
        
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
