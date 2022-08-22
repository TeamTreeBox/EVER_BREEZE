using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChange : MonoBehaviour
{
    public GameObject page01;
    public GameObject page02;

    bool isPage01;
    void Start()
    {
        page01.SetActive(true);
        page02.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (PageManager.instance.debug_StageClear == 1 && isPage01 == false)
        {
            print("&&º¯°æ&&");
           page01.SetActive(false);
           page02.SetActive(true);
        }
    }
}
