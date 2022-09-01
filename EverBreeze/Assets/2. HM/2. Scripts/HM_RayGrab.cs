using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_RayGrab : MonoBehaviour
{
    public static HM_RayGrab instance;
    
    private void Awake()
    {
        instance = this;
    }

    RaycastHit hit;
    int layerMask;

    public GameObject grapPos;
    public GameObject grapable;


   

    public bool isGrabOn = false;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 6;        
    }

    public void NullGrabable()
    {
        grapable = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrabOn == false && OVRInput.GetDown(OVRInput.Button.One))
        {
            if(Physics.Raycast(transform.position,transform.forward,out hit, 500f, layerMask))
            {
                print("hit!");
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

                grapable = hit.transform.gameObject;

                if(grapable.gameObject != null)
                {

                    grapable.transform.SetParent(grapPos.transform);

                    grapable.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    grapable.transform.localPosition = Vector3.zero;

                    if (grapable.tag == "WaterBall")
                    {
                        grapable.GetComponent<HM_WaterQuest>().SizeChangeWaterVFX();
                    }
                    else if(grapable.tag == "JingleBell")
                    {
                        grapable.transform.localScale = new Vector3(.8f, .8f, .8f);
                    }

                    isGrabOn = true;
                }
                
            }
            else
            { 
                Debug.DrawRay(transform.position, transform.forward * 300f, Color.red);
            }
        }
        else if(isGrabOn == true && OVRInput.GetDown(OVRInput.Button.One))
        {
            if(grapable.gameObject != null)
            {
                grapable.transform.localScale = new Vector3(.2f, .2f, .2f);
                grapable.transform.SetParent(null);

                isGrabOn = false;
            }
        }
    }
}
