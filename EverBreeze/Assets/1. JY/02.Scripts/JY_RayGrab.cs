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

    RaycastHit hit;
    int layerMask;

    public GameObject grabPos;
    public GameObject grabable;

    public bool isGrabOn = false;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 6;
    }

    public void NullGrabable()
    {
        grabable = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrabOn == false && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 300f, layerMask))
            {
                print("hit!");
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

                grabable = hit.transform.gameObject;

                grabable.transform.SetParent(grabPos.transform);

                grabable.transform.localPosition = Vector3.zero;
                grabable.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                isGrabOn = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 300f, Color.red);
            }
        }
        else if (isGrabOn == true && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            grabable.transform.SetParent(null);

            isGrabOn = false;
        }
    }
}
