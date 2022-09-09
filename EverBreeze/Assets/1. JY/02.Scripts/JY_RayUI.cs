using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_RayUI : MonoBehaviour
{
    public static JY_RayUI instance;
    private void Awake()
    {
        instance = this;
    }
    public RaycastHit hit;
    int layerMask01;

    public GameObject hitThing;
    public GameObject bookMark01;
    public GameObject bookMark02;
    public GameObject bookMark03;
    public GameObject bookMark04;

    private bool state;

    void Start()
    {
        layerMask01 = 1 << 9;
        state = false;
    }

    public void Update()
    {
        //SecondaryHandTrigger ��ư�� On Off ����
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            state = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            state = false;
        }

        //Ray Hit�� �� �Ǿ� ���� �� ����
        if (state == false)
        {
            bookMark01.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            bookMark02.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            bookMark03.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            bookMark04.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        //Ray Hit�� �Ǿ��� �� ����
        if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask01))
        {
            if (state == true)
            {
                hitThing = hit.transform.gameObject;
                print(hitThing.gameObject.name);
                //���� O
                if (hitThing.gameObject == bookMark01)
                {
                    hitThing.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                }

                if (hitThing.gameObject == bookMark02)
                {
                    hitThing.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                }

                if (hitThing.gameObject == bookMark03)
                {
                    hitThing.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                }

                if (hitThing.gameObject == bookMark04)
                {
                    hitThing.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                }

                //���� X
                if (hitThing.gameObject != bookMark01)
                {
                    bookMark01.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                if (hitThing.gameObject != bookMark02)
                {
                    bookMark02.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                if (hitThing.gameObject != bookMark03)
                {
                    bookMark03.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                if (hitThing.gameObject != bookMark04)
                {
                    bookMark04.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
            }
        }

    }
}
