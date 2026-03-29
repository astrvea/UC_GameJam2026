using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabNew : MonoBehaviour
{
    public Camera mainCam;
    public Transform grabArea;
    public GameObject grabbedObj;
    public GameObject player;
    public LayerMask grabbableLayer;

    void Start()
    {
        grabbableLayer = LayerMask.GetMask("Grabbable");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("wassup");
            checkRaycast();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObj)
            {
                dropObject();
            }
        }
        moveGrabbed();
    }

    void moveGrabbed()
    {
        if (grabbedObj)
        {
            grabbedObj.transform.position = grabArea.position;
        }
    }

    void checkRaycast()
    {
        // cast ray from player to mouse position; if hit item with component GrabbableObject, "grab" object
        // Vector3 screenPoint = Input.mousePosition;
        // screenPoint.z = mainCam.farClipPlane;
        // Vector3 worldPoint = mainCam.ScreenToWorldPoint(screenPoint);
        // Ray cameraRay = new Ray(mainCam.transform.position, (worldPoint - mainCam.transform.position).normalized);
        // Debug.DrawLine(cameraRay.origin, cameraRay.origin + cameraRay.direction * 100, Color.blue);
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 50, Color.red);

        Vector3 targetWorldPoint = new Vector3();
        RaycastHit cameraHit;

        // check to see if the player actually clicked anything
        if (Physics.Raycast(cameraRay, out cameraHit, Mathf.Infinity, grabbableLayer))
        {
            GrabbableObject grab = cameraHit.collider.GetComponent<GrabbableObject>();
            Debug.DrawLine(cameraRay.origin, cameraHit.point, Color.red);
            Debug.Log(cameraHit.collider.name);
            if (!grab)
            {
                return;
            }
            targetWorldPoint = cameraHit.point;
            Debug.Log("actually grabbed something");
        }
        else
        {
            return;
        }

        Vector3 dirToObj = (targetWorldPoint - player.transform.position).normalized;

        // check to see if there's something in between the player and the grabbable
        if (Physics.Raycast(player.transform.position, dirToObj, out cameraHit, Vector3.Distance(player.transform.position, targetWorldPoint), grabbableLayer))
        {
            Debug.Log(cameraHit.collider.name);
            if (cameraHit.collider.GetComponent<GrabbableObject>())
            {
                Debug.Log("Grabbable object found");
                grabObj(cameraHit.collider.gameObject);
            }
            else
            {
                // hit something else (not grabbable)
                return;
            }
        }
    }

    void grabObj(GameObject obj)
    {
        // check to see if we already have grabbed object; if yes, swap. if no, set grabbedObj
        if (grabbedObj)
        {
            // swap the objects
            grabbedObj.transform.position = obj.transform.position;
            grabbedObj = obj;
            grabbedObj.transform.position = grabArea.position;
        }
        else
        {
            // set the grabbed object
            grabbedObj = obj;
            grabbedObj.transform.position = grabArea.position;
        }
    }

    void dropObject()
    {
        // drop the object by setting grabbedObj to null
        grabbedObj = null;
    }
}
