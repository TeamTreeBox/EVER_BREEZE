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
    public Transform rightHand;

    public RaycastHit hit;
    int layerMask01;

    public GameObject hitThing;

    private bool state;
    private bool activeState;

    void Start()
    {
        layerMask01 = 1 << 5;
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

        //One ��ư�� On Off ����
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            activeState = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            activeState = false;
        }
 
        //Ray Hit�� �Ǿ��� �� ����
        if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask01))
        {
            if (state == true)
            {
                hitThing = hit.transform.gameObject;
                print("UI" + " " + hitThing.gameObject.name);
                //���� O
                if (activeState == true)
                {
                    Button btn = hitThing.transform.GetComponent<Button>();
                    if (hitThing != null)
                    {
                        btn.onClick.Invoke();
                    }
                }
            }
        }

    }
}
