using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class StopStateCheck : MonoBehaviour
{
    public bool gatherState = false;
    public bool stopState = false;
    public GameObject Player;
    Vector3 lastPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckChangePosition();
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

    void CheckChangePosition()
    {
        if (lastPos != Player.transform.position)
        {
            stopState = false;
            lastPos = Player.transform.localPosition;
           
        }   
        else if(lastPos == Player.transform.position)
        {
            stopState = true;
        }
    }
}
