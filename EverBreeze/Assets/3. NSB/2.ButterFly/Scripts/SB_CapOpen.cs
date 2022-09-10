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
            Cap.transform.localPosition = new Vector3(-0.0689999983f, -0.342999995f, -0.0590000004f);
            isGrabOn = true;
          
     
        }
 
    }

}
