using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookVR : MonoBehaviour
{
    //Book UI
    public GameObject book;
    //Book이 나타나는 위치
    public GameObject anchor;
    //UI 감지
    bool UIActive;

    void Start()
    {
        book.SetActive(false);
        UIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //X버튼을 누를 시
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            //UI가 false면 true로 바꿔준다.
            UIActive = !UIActive;
            //UI True
            book.SetActive(UIActive);

        }
        //Book이 나타나는 Position
        if (UIActive)
        {
            //Book Anchor의 위치 = Left Hand의 위치 
            book.transform.position = anchor.transform.position;
            book.transform.eulerAngles = new Vector3(anchor.transform.eulerAngles.x, anchor.transform.eulerAngles.y, anchor.transform.eulerAngles.z);
        }
    }
}
