using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class SB_StopStateCheck : MonoBehaviour
{
    public bool gatherState = false;
    public bool stopState;
    public GameObject Player;
    Vector3 lastPos;


    // Start is called before the first frame update
    void Start()
    {
            stopState = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) !=Vector2.zero)
        {
            stopState = false ;
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) == Vector2.zero)
        {
            stopState = true;
        }

        if (OVRInput.GetDown(OVRInput.Touch.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            stopState = false;

        }

        else if (OVRInput.GetUp(OVRInput.Touch.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            stopState = true;

        }





    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "GatherZone")
        {
            gatherState = true;
            print("g");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GatherZone")
        {
            gatherState = false;
            print("b");
        }
    }

}
