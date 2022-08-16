using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookVR : MonoBehaviour
{
    //Book UI
    public GameObject book;
    //Book�� ��Ÿ���� ��ġ
    public GameObject anchor;
    //UI ����
    bool UIActive;

    void Start()
    {
        book.SetActive(false);
        UIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //X��ư�� ���� ��
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            //UI�� false�� true�� �ٲ��ش�.
            UIActive = !UIActive;
            //UI True
            book.SetActive(UIActive);

        }
        //Book�� ��Ÿ���� Position
        if (UIActive)
        {
            //Book Anchor�� ��ġ = Left Hand�� ��ġ 
            book.transform.position = anchor.transform.position;
            book.transform.eulerAngles = new Vector3(anchor.transform.eulerAngles.x, anchor.transform.eulerAngles.y, anchor.transform.eulerAngles.z);
        }
    }
}
