using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_RayGrab : MonoBehaviour
{
   RaycastHit hit;
    int layerMask;

    public GameObject grapPos;
    public GameObject grapable;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 6;        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if(Physics.Raycast(transform.position,transform.forward,out hit, 300f, layerMask))
            {
                print("hit!");
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

                grapable = hit.transform.gameObject;

                grapable.transform.SetParent(grapPos.transform);

                grapable.transform.localPosition = Vector3.zero;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 300f, Color.red);
            }
        }
    }
}
