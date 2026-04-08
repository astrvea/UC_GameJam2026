using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwap : MonoBehaviour
{
    private float myPos;
    public GameObject myPlay;
    public GameObject myShadow;

    
    public ShadowTime St;
    //public float orgY;
    //public float orgX;
    //public float orgZ;
    public Vector3 Offset;
    public Vector3 OrgStart;
    public float speed;

    public float rotSpeed;

    public Quaternion targetRot;

    public Quaternion orgRot;

    public Vector3 targetLocation;

    //public CinemachineVirtualCamera vCamera;

    public CinemachineVirtualCamera virtCam;

    public GameObject vCamera;

    public bool hasMoved = false;

    //public GrabItem grabber;

    //public GameObject itemShadow;

    public GameObject player;
    

    public void Start()
    {
        //orgY = Camera.main.transform.rotation.y;
        //orgX = Camera.main.transform.rotation.x;
        //orgZ = Camera.main.transform.rotation.z;

        targetRot = Quaternion.Euler(15, 90, 0);
        orgRot = Quaternion.Euler(30, 45, 0);

      
        //vCamera = GetComponent<CinemachineVirtualCamera>();


        


    }
    public void Update()
    {

        targetLocation = myShadow.transform.position + Offset;
        
        if (St.ShadowGo == true )
        {
            //Camera.main.transform.rotation = Quaternion.Euler(15, 90, 0);

            Camera.main.orthographic = false;

            //Camera.main.transform.position = myShadow.transform.position + Offset;

            //Camera.main.transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);

            if (hasMoved == false) 
            {
                Camera.main.transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);

                vCamera.transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);

                hasMoved = true;
            }

            Camera.main.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);

            vCamera.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);

            virtCam.Follow = myShadow.transform;
            virtCam.LookAt = myShadow.transform;

            //if (grabber.isGrabbed == true) 
            //{

                //itemShadow.SetActive(true);

            //}

            
        }

        if (St.ShadowGo == false)
        {

            //Camera.main.transform.rotation = Quaternion.Euler(30, 45, 0);

            //Camera.main.transform.position = OrgStart;
            //vCamera.transform.position = OrgStart;

            Camera.main.transform.position = Vector3.MoveTowards(transform.position, OrgStart, speed * Time.deltaTime);

            vCamera.transform.position = Vector3.MoveTowards(transform.position, OrgStart, speed * Time.deltaTime);

            Camera.main.transform.rotation = Quaternion.RotateTowards(transform.rotation, orgRot, rotSpeed * Time.deltaTime);

            vCamera.transform.rotation = Quaternion.RotateTowards(transform.rotation, orgRot, rotSpeed * Time.deltaTime);
            Camera.main.orthographic = true;

            virtCam.Follow = player.transform;
            virtCam.LookAt = player.transform;


            //itemShadow.SetActive(false);




        }



    }
}
