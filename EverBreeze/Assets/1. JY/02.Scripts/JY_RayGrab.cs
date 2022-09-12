using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_RayGrab : MonoBehaviour
{
    public static JY_RayGrab instance;
    private void Awake()
    {
        instance = this;
    }

    public RaycastHit hit;
    int layerMask00;

    public GameObject grabPos;
    public GameObject jingleBellGrabPos;
    public GameObject grabable;
    public GameObject hitThing;

    public bool isGrabOn = false;

    //public GameObject waterFactory;

    // Start is called before the first frame update
    void Start()
    {
        layerMask00 = 1 << 6;

        isGrabOn = false;
        isSlotOff = false;
    }

    public void NullGrabable()
    {
        if(grabable!=null)
        {
        grabable = null;
        }
    }

    public bool slotHit;
    public bool isSlotOff;
    public bool isSlotScale;

    public void Update()
    {
        //print("isGrabOn" + " " + isGrabOn);
        if (isGrabOn == false && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask00))
            {
                //print("hit!");
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

                grabable = hit.transform.gameObject;

                if (grabable.gameObject != null)
                {
                    isGrabOn = true;
                    grabable.transform.SetParent(grabPos.transform);

                    if (grabable.tag == "WaterBall")
                    {
                        grabable.GetComponent<HM_WaterQuest>().SizeChangeWaterVFX();

                    }
                    else if (grabable.tag == "JingleBell")
                    {
                        grabable.transform.SetParent(jingleBellGrabPos.transform);
                        grabable.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        grabable.transform.localPosition = new Vector3(0.0287f, -0.04f, 0.0254f);
                        grabable.transform.localRotation = Quaternion.Euler(new Vector3(20.0f, 0.0f, -170.0f));
                    }
                    else if (grabable.tag == "JamStone")
                    {
                        grabable.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    }
                    else if (grabable.tag == "Branch")
                    {
                        grabable.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    else if (grabable.tag == "Bottle")
                    {
                        grabable.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                    }
                    
                    grabable.transform.localPosition = Vector3.zero;

                    grabable.gameObject.GetComponent<Rigidbody>().useGravity = false;

                    grabable.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

                    grabable.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                    grabable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
                    
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.forward * 300f, Color.red);
                }
            }
        }
        else if (isGrabOn == true && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            if (grabable.gameObject != null)
            {
                print("Select Hit OUT");

                GrabOff();
            }
        }
    }
    public void GrabOff()
    {
        print("%%Slot Hit OUT%%");
        grabable.transform.SetParent(null);
        grabable.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        if (grabable.tag == "JingleBell")
        {
            grabable.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (grabable.tag == "JamStone")
        {
            grabable.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (grabable.tag == "Bottle")
        {
            grabable.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
        }
        isGrabOn = false;
        grabable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Field;

        grabable.GetComponent<Rigidbody>().useGravity = true;

        grabable.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }
}

