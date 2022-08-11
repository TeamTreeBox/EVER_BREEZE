using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookVR : MonoBehaviour
{
    public GameObject book;
    public GameObject anchor;
    bool UIActive;

    void Start()
    {
        book.SetActive(false);
        UIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            UIActive = !UIActive;
            book.SetActive(UIActive);

        }
        if (UIActive)
        {
            book.transform.position = anchor.transform.position;
            book.transform.eulerAngles = new Vector3(anchor.transform.eulerAngles.x, anchor.transform.eulerAngles.y, 0);
        }
    }
}
