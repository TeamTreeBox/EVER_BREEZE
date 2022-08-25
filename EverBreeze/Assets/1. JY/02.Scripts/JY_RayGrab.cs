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
    int layerMask01;

    public GameObject grabPos;
    public GameObject grabable;

    public bool isGrabOn = false;

    //public GameObject waterFactory;

    // Start is called before the first frame update
    void Start()
    {
        layerMask00 = 1 << 6;
        layerMask01 = 1 << 7;
    }

    public void NullGrabable()
    {
        grabable = null;
    }

    public bool slotHit;
    public bool isSlotOff;

    // Update is called once per frame
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

                    grabable.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    grabable.transform.localPosition = Vector3.zero;

                    if (grabable.tag == "WaterBall")
                    {
                        grabable.GetComponent<HM_WaterQuest>().SizeChangeWaterVFX();
                    }


                    grabable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 300f, Color.red);
            }

            if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask01))
            {
                if (hit.transform.GetComponent<JY_Slot1>().isInitem == true && isGrabOn == false && isSlotOff == false && OVRInput.GetDown(OVRInput.Button.One))
                {
                    isSlotOff = true;
                    isGrabOn = true;
                }
                /*if (grabable.GetComponent<JY_Slot>().isWaterItemIn == true)
                {
                    grabable.GetComponent<JY_Slot>().water.gameObject.SetActive(false);

                    GameObject waterNew = Instantiate(waterFactory);
                    waterNew.transform.position = grabPos.transform.position;

                    grabable.GetComponent<JY_Slot>().waterCount--;

                    grabable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
                }*/
            }
        }
        else if (isGrabOn == true && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            if (grabable.gameObject != null)
            {
                print("%%OUT%%");
                grabable.transform.SetParent(null);
                grabable.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                isGrabOn = false;
                grabable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Field;
            }
            }
        }
}
