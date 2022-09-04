using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_RaySlot : MonoBehaviour
{
    public static JY_RaySlot instance;
    private void Awake()
    {
        instance = this;
    }

    public RaycastHit hit;
    int layerMask01;

    public GameObject hitThing;
    public GameObject slot01;
    public GameObject slot02;
    public GameObject slot03;

    private bool state;
    private bool infoState;

    public GameObject waterItemInfo;

    void Start()
    {
        layerMask01 = 1 << 7;
        state = false;
    }

    public void Update()
    {
        //버튼을 On Off 여부
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            state = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            state = false;
        }


        //Ray Hit가 안 되어 있을 떄 상태
        if (state == false)
        {
            slot01.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            slot02.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            slot03.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        //Ray Hit가 되었을 떄 상태
        if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask01))
        {
            if (state == true)
            {
                hitThing = hit.transform.gameObject;

                //선택 O
                if (hitThing.gameObject == slot01)
                {
                    hitThing.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                    if (OVRInput.GetDown(OVRInput.Button.Two))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                }

                if (hitThing.gameObject == slot02)
                {
                    hitThing.transform.localScale = new Vector3(0.225f, 0.25f, 0.25f);
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                }

                if (hitThing.gameObject == slot03)
                {
                    hitThing.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                }

                //선택 X
                if (hitThing.gameObject != slot01)
                {
                    slot01.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                if (hitThing.gameObject != slot02)
                {
                    slot02.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                if (hitThing.gameObject != slot03)
                {
                    slot03.transform.localScale = new Vector3(0.22f, 0.2f, 0.2f);
                }
            }
        }
    }
}
