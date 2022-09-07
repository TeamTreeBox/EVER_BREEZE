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
    private bool activeState;

    public GameObject waterItemInfo;
    public GameObject branchItemInfo;
    public GameObject jamStonneItemInfo;
    public GameObject jingleBellItemInfo;

    void Start()
    {
        layerMask01 = 1 << 7;
        state = false;

        jingleBellItemInfo.SetActive(false);
    }

    public void INItemInfo()
    {
        if (hitThing.transform.GetChild(0).gameObject.CompareTag("WaterBall"))
        {
            print("**들어옴**");
            waterItemInfo.SetActive(true);
        }
        else if (hitThing.transform.GetChild(0).gameObject.tag == "Branch")
        {
            branchItemInfo.SetActive(true);
        }
        else if (hitThing.transform.GetChild(0).gameObject.tag == "JamStone")
        {
            jamStonneItemInfo.SetActive(true);
        }
        else if (hitThing.transform.GetChild(0).gameObject.tag == "JingleBell")
        {
            jingleBellItemInfo.SetActive(true);
        }
    }

    public void OUTItemInfo()
    {
        if (hitThing.transform.GetChild(0).gameObject.tag == "WaterBall")
        {
            print("**나감**");
            waterItemInfo.SetActive(false);
        }
        else if (hitThing.transform.GetChild(0).gameObject.tag == "Branch")
        {
            branchItemInfo.SetActive(false);
        }
        else if (hitThing.transform.GetChild(0).gameObject.tag == "JamStone")
        {
            jamStonneItemInfo.SetActive(false);
        }
        else if (hitThing.transform.GetChild(0).gameObject.tag == "JingleBell")
        {
            jingleBellItemInfo.SetActive(false);
        }
    }

    public void Update()
    {
        //SecondaryHandTrigger 버튼을 On Off 여부
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            state = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            state = false;
        }

        //Two 버튼을 On Off 여부
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            activeState = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            activeState = false;
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
                print(hitThing.gameObject.name);
                //선택 O
                if (hitThing.gameObject == slot01)
                {
                    hitThing.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                    //Item Info
                    if (activeState == true)
                    {
                        INItemInfo();
                    }
                    else if (activeState == false && hitThing.transform.childCount != 0)
                    {
                        OUTItemInfo();
                    }
                }

                else if (hitThing.gameObject == slot02)
                {
                    hitThing.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                    //Item Info
                    if (activeState == true)
                    {
                        INItemInfo();
                    }
                    else if (activeState == false && hitThing.transform.childCount != 0)
                    {
                        OUTItemInfo();
                    }
                }

                else if (hitThing.gameObject == slot03)
                {
                    hitThing.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hitThing.GetComponent<JY_Slot1>().OutItem();
                    }
                    //Item Info
                    if (activeState == true)
                    {
                        INItemInfo();
                    }
                    else if (activeState == false && hitThing.transform.childCount != 0)
                    {
                        OUTItemInfo();
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
