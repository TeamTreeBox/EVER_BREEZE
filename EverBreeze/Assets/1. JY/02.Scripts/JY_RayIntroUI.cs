using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_RayIntroUI : MonoBehaviour
{
    public static JY_RayIntroUI instance;
    private void Awake()
    {
        instance = this;
    }

    public RaycastHit hit;
    int layerMask00;

    public GameObject hitThing;
    public GameObject newGameBT;
    public GameObject continueBT;
    public GameObject optionUI;
    public GameObject exitUI;

    private bool state;

    void Start()
    {
        layerMask00 = 1 << 5;
        state = false;
    }

    public void Update()
    {
        //��ư�� On Off ����
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            state = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            state = false;
        }

        if (state == false)
        {
            newGameBT.transform.GetChild(0).gameObject.SetActive(false);
            continueBT.transform.GetChild(0).gameObject.SetActive(false);
            optionUI.transform.GetChild(0).gameObject.SetActive(false);
            exitUI.transform.GetChild(0).gameObject.SetActive(false);
        }

        //Ray Hit�� �Ǿ��� �� ����
        if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask00))
        {
            if (state == true)
            {
                hitThing = hit.transform.gameObject;

                //���� O
                if (hitThing.gameObject == newGameBT)
                {
                    newGameBT.transform.GetChild(0).gameObject.SetActive(true);
                }

                if (hitThing.gameObject == continueBT)
                {
                    continueBT.transform.GetChild(0).gameObject.SetActive(true);
                }

                if (hitThing.gameObject == optionUI)
                {
                    optionUI.transform.GetChild(0).gameObject.SetActive(true);
                }
                
                if (hitThing.gameObject == exitUI)
                {
                    exitUI.transform.GetChild(0).gameObject.SetActive(true);
                }

                //���� X
                if (hitThing.gameObject != newGameBT)
                {
                    newGameBT.transform.GetChild(0).gameObject.SetActive(false);
                }
                if (hitThing.gameObject != continueBT)
                {
                    continueBT.transform.GetChild(0).gameObject.SetActive(false);
                }
                if (hitThing.gameObject != optionUI)
                {
                    optionUI.transform.GetChild(0).gameObject.SetActive(false);
                }
                if (hitThing.gameObject != exitUI)
                {
                    exitUI.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
