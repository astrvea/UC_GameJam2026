using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rocket : MonoBehaviour
{
    private PlayerGrabNew playerHand;
    private bool isCatBowlInRange;
    private bool isVolcanoInRange;
    private bool isLanternInRange;
    public TextMeshProUGUI macguffinStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerHand = FindObjectOfType<PlayerGrabNew>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHand.grabbedObj == null)
        {
            checkArea();
        }
    }

    void checkArea()
    {
        isCatBowlInRange = false;
        isVolcanoInRange = false;
        isLanternInRange = false;
        BoxCollider box = GetComponent<BoxCollider>();
        Vector3 boxCenter = box.bounds.center;
        Vector3 boxSize = box.bounds.size;
        Collider[] hitColls = Physics.OverlapBox(boxCenter, boxSize / 2f, Quaternion.identity, playerHand.grabbableLayer);
        string hitNames = "";
        foreach (Collider col in hitColls)
        {
            Debug.Log(col.attachedRigidbody.name + " hit");
            if (col.attachedRigidbody.GetComponent<GrabbableObject>() == null)
            {
                continue;
            }
            if (col.attachedRigidbody.GetComponent<GrabbableObject>().baseItem.name == "cat bowl")
            {
                isCatBowlInRange = true;
            }
            else if (col.attachedRigidbody.GetComponent<GrabbableObject>().baseItem.name == "volcano")
            {
                isVolcanoInRange = true;
            }
            else if (col.attachedRigidbody.GetComponent<GrabbableObject>().baseItem.name == "lantern")
            {
                isLanternInRange = true;
            }
        }
        hitNames += isCatBowlInRange == true ? "cat bowl obtained\n" : "No cat bowl\n";
        hitNames += isVolcanoInRange == true ? "volcano obtained\n" : "No volcano\n";
        hitNames += isLanternInRange == true ? "lantern obtained\n" : "No lantern\n";
        macguffinStatus.text = hitNames;
    }
}
