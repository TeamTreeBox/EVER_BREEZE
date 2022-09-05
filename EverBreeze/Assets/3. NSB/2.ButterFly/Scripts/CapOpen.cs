using Facebook.WitAi;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapOpen : MonoBehaviour
{

    public GameObject Cap;
    public bool isGrabOn = false;
    public GameObject GrapPos;
    public GameObject CapPos;

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
            Cap.transform.localPosition = new Vector3(-0.1f, 0.07f, 0.17f);
            isGrabOn = true;
          
     
        }
 
    }

}
