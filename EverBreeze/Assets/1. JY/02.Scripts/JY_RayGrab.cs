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
    public GameObject grapable;

    public bool isGrabOn = false;

    public GameObject waterFactory;

    // Start is called before the first frame update
    void Start()
    {
        layerMask00 = 1 << 6;
        layerMask01 = 1 << 7;
    }

    public void NullGrabable()
    {
        grapable = null;
    }

    bool slotHit;
    // Update is called once per frame
    void Update()
    {
        print("isGrabOn" + " " + isGrabOn);
        if (isGrabOn == false && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask00))
            {
                print("hit!");
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

                grapable = hit.transform.gameObject;

                if (grapable.gameObject != null)
                {
                    isGrabOn = true;
                    grapable.transform.SetParent(grabPos.transform);

                    grapable.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    grapable.transform.localPosition = Vector3.zero;

                    if (grapable.tag == "WaterBall")
                    {
                        grapable.GetComponent<HM_WaterQuest>().SizeChangeWaterVFX();
                    }

                    
                    grapable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 300f, Color.red);
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask01))
            {
                grapable = hit.transform.gameObject;
                if (grapable.GetComponent<JY_Slot>().isWaterItemIn == true)
                {
                    grapable.GetComponent<JY_Slot>().water.gameObject.SetActive(false);

                    GameObject waterNew = Instantiate(waterFactory);
                    waterNew.transform.position = grabPos.transform.position;

                    //grapable.GetComponent<JY_Slot>().waterCount--;

                    grapable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
                }
            }
        }
        else if (isGrabOn == true && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            if (grapable.gameObject != null)
            {
                print("%%OUT%%");
                grapable.transform.SetParent(null);
                grapable.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                isGrabOn = false;
                grapable.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Field;
            }
            }
        }
}
