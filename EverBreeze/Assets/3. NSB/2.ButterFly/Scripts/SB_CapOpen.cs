using Facebook.WitAi;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_CapOpen : MonoBehaviour
{

    public GameObject Cap;
    public bool isGrabOn = false;
    public GameObject GrapPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "OpenCap" && isGrabOn == false)
        { 
            Cap.transform.position = Vector3.zero;
            Cap.transform.SetParent(GrapPos.transform);
            Cap.transform.localPosition = new Vector3(-0.0456000008f, -0.161799997f, 0.057f);
            isGrabOn = true;
          
     
        }
 
    }

}
