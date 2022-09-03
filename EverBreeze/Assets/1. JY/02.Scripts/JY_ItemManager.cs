using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_ItemManager : MonoBehaviour
{
    //JamStone Item Info 
    public GameObject info01;
    public GameObject info02;
    public GameObject info03;

    bool isInfo01 = true;
    bool isInfo02 = false;
    bool isInfo03 = false;

    void Start()
    {
        //JamStone Item Info
        info01.SetActive(true);
        info02.SetActive(false);
        info03.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //JamStone Item Info
        if (JY_ItemDebug.instance.debug_Item == 1 && isInfo01 == true && isInfo02 == false && isInfo03 == false)
        {
            info01.SetActive(false);
            info02.SetActive(true);
            isInfo01 = false;
            isInfo02 = true;
        }

        if (JY_ItemDebug.instance.debug_Item == 2 && isInfo01 == false && isInfo02 == true && isInfo03 == false)
        {
            info02.SetActive(false);
            info03.SetActive(true);
            isInfo02 = false;
            isInfo03 = true;
        }
    }
}
