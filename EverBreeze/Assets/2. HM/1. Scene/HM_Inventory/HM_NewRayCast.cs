using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_NewRayCast : MonoBehaviour
{
    public static HM_NewRayCast instance;

    private void Awake()
    {
        instance = this;
    }

    RaycastHit hit;
    int layerMask;
    int layerMaskSlot;

    public GameObject grapPos;
    public GameObject grapable;

    public bool isGrabOn = false;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 6;
        layerMaskSlot = 1 << 7;
    }

    public void NullGrabable()
    {
        grapable = null;
    }

    // Update is called once per frame
    void Update()
    {
        print(isGrabOn);
        if (isGrabOn == false && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask))
            {
                print("hit!");
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

                grapable = hit.transform.gameObject;

                GrabItem(hit.transform.gameObject);

            }

            else if(Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMaskSlot))
            {
                print("slothit!");

                hit.transform.gameObject.GetComponent<HM_Slot>().WaterReleaseItem();
            }
        }
        else if (isGrabOn == true && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (grapable.gameObject != null)
            {
                grapable.transform.SetParent(null);

                grapable.transform.localScale = new Vector3(1f, 1f, 1f);

                grapable.GetComponent<Rigidbody>().useGravity = true;
                isGrabOn = false;
            }
        }

        
    }

    public void GrabItem(GameObject hit)
    {
        if (hit.gameObject != null)
        {
            grapable = hit.transform.gameObject;

            hit.transform.SetParent(grapPos.transform);

            if (hit.tag == "WaterBall")
            {
                hit.GetComponent<HM_WaterQuest>().SizeChangeWaterVFX();
            }
            else
            {
                hit.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            }


            hit.transform.localPosition = Vector3.zero;

            hit.GetComponent<Rigidbody>().useGravity = false;

            hit.GetComponent<HM_NewItemInfo>().state = HMItemState.Grab;
            isGrabOn = true;
        }
    }
}
