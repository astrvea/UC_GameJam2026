using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerLadder : MonoBehaviour
{

    public bool ladderPushed = false;

    public Rigidbody ladderRb;

    public GameObject ladder;

    public GameObject colliderBoxes;

    public float dropTime;

    public GameObject ladderEndPos;

    public LadderShadowColOff shadowOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ladder.transform.position.y <= ladderEndPos.transform.position.y) 
        
        {

            shadowOff.turnOff = false;

        }


    }

    public void FixedUpdate()
    {
        if (ladderPushed == true)
        {

            ladderRb.useGravity = true;
            
            StartCoroutine(incDrop());
            
        }

        if (ladder.transform.position.y <= ladderEndPos.transform.position.y) 
        {

            
            ladderPushed = false;
            colliderBoxes.SetActive(false);
            ladderRb.useGravity = false;
            ladderRb.constraints = RigidbodyConstraints.FreezeAll;
            shadowOff.turnOff = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LadderEnd")) 
        {
            ladderRb.useGravity = false;
            ladderRb.isKinematic = false;
            colliderBoxes.SetActive(false);
            ladderRb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    IEnumerator incDrop() 
    
    {

        yield return new WaitForSeconds(dropTime);
        ladderRb.useGravity = false;
        ladderRb.isKinematic = false;
        ladderPushed = false;
    }
}
