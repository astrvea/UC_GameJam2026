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
    public GameObject topRocket;
    public GameObject middleRocket;
    public GameObject bottomRocket;
    public GameObject wholeRocket;
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
        Collider[] hitColls = Physics.OverlapBox(boxCenter, boxSize / 3f, Quaternion.identity, playerHand.grabbableLayer);
        string hitNames = "";
        foreach (Collider col in hitColls)
        {
            Debug.Log(col.attachedRigidbody.name + " hit");
            if (col.attachedRigidbody.GetComponent<GrabbableObject>() == null)
            {
                continue;
            }
            if (col.attachedRigidbody.GetComponent<GrabbableObject>().baseItem.name == "catbowl")
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
        // hitNames += isCatBowlInRange == true ? "cat bowl obtained\n" : "No cat bowl\n";
        // hitNames += isVolcanoInRange == true ? "volcano obtained\n" : "No volcano\n";
        // hitNames += isLanternInRange == true ? "lantern obtained\n" : "No lantern\n";
        // macguffinStatus.text = hitNames;
        StartCoroutine(isCatBowlInRange == true? showPart("catbowl") : hidePart("catbowl"));
        StartCoroutine(isVolcanoInRange == true? showPart("volcano") : hidePart("volcano"));
        StartCoroutine(isLanternInRange == true? showPart("lantern") : hidePart("lantern"));
        if (isCatBowlInRange && isVolcanoInRange && isLanternInRange)
        {
            StartCoroutine(showPart("wholeRocket"));
        }
    }

    IEnumerator showPart(string name)
    {
        Color c = new Color(0f, 0f, 0f, 0f);
        SpriteRenderer sr = new SpriteRenderer();
        switch (name)
        {
            case "catbowl":
                c = topRocket.GetComponent<SpriteRenderer>().color;
                sr = topRocket.GetComponent<SpriteRenderer>();
                break;
            case "volcano":
                c = middleRocket.GetComponent<SpriteRenderer>().color;
                sr = middleRocket.GetComponent<SpriteRenderer>();
                break;
            case "lantern":
                c = bottomRocket.GetComponent<SpriteRenderer>().color;
                sr = bottomRocket.GetComponent<SpriteRenderer>();
                break;
            case "wholeRocket":
                c = wholeRocket.GetComponent<SpriteRenderer>().color;
                sr = wholeRocket.GetComponent<SpriteRenderer>();
                break;
        }
        while (c.a < 1)
        {
            c.a += Time.deltaTime;
            sr.color = c;
            yield return null;
        }
    }

    IEnumerator hidePart(string name)
    {
        Color c = new Color(0f, 0f, 0f, 0f);
        SpriteRenderer sr = new SpriteRenderer();
        switch (name)
        {
            case "catbowl":
                c = topRocket.GetComponent<SpriteRenderer>().color;
                sr = topRocket.GetComponent<SpriteRenderer>();
                break;
            case "volcano":
                c = middleRocket.GetComponent<SpriteRenderer>().color;
                sr = middleRocket.GetComponent<SpriteRenderer>();
                break;
            case "lantern":
                c = bottomRocket.GetComponent<SpriteRenderer>().color;
                sr = bottomRocket.GetComponent<SpriteRenderer>();
                break;
        }
        while (c.a > 0)
        {
            c.a -= Time.deltaTime;
            sr.color = c;
            yield return null;
        }
    }
}
