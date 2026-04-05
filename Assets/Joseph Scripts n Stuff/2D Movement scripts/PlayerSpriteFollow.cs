using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteFollow : MonoBehaviour
{

    public GameObject playerCapsule;

    public GameObject playerSprite;

    public ShadowTime st;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerSprite.transform.position = playerCapsule.transform.position;

        if (st.ShadowGo == true) 
        {
            playerSprite.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (st.ShadowGo == false) 
        {
            playerSprite.transform.rotation = Quaternion.Euler(-30, -135, 0);
        }
    }


    public void FixedUpdate()
    {
        //playerSprite.transform.position = playerCapsule.transform.position;
    }
}
