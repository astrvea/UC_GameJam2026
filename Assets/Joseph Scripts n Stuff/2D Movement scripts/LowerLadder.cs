using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerLadder : MonoBehaviour
{

    public bool ladderPushed = false;

    public Rigidbody ladderRb;

    public GameObject ladder;

    public GameObject colliderBoxes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (ladderPushed == true)
        {

            ladderRb.useGravity = true;
            ladderRb.isKinematic = true;
            
        }

        if (ladder.transform.position.y <= 2.5) 
        {

            ladderRb.constraints = RigidbodyConstraints.FreezeAll;
            ladderPushed = false;
            colliderBoxes.SetActive(false);
            ladderRb.useGravity = false;
            ladderRb.isKinematic = false;
        }
    }
}
