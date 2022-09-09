using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_ItemManager : MonoBehaviour
{
    //JamStone Item Info 
    public GameObject jamStoneInfo01;
    public GameObject jamStoneInfo02;
    public GameObject jamStoneInfo03;

    bool jamStoneIsInfo01 = true;
    bool jamStoneIsInfo02 = false;

    //Bottle Item Info 
    public GameObject bottleInfo01;
    public GameObject bottleInfo02;
    public GameObject bottleInfo03;
    public GameObject bottleInfo04;

    bool bottleIsInfo01 = true;
    bool bottleIsInfo02 = false;
    bool bottleIsInfo03 = false;

    void Start()
    {
        //JamStone Item Info 01 활성화
        jamStoneInfo01.SetActive(true);
        jamStoneInfo02.SetActive(false);
        jamStoneInfo03.SetActive(false);

        //Bottle Item Info 01 활성화
        bottleInfo01.SetActive(true);
        bottleInfo02.SetActive(false);
        bottleInfo03.SetActive(false);
        bottleInfo04.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //JamStone Item Info
        if (JY_ItemDebug.instance.debug_JamStoneItem == 1 && jamStoneIsInfo01 == true && jamStoneIsInfo02 == false)
        {
            jamStoneInfo01.SetActive(false);
            jamStoneInfo02.SetActive(true);
            jamStoneIsInfo01 = false;
            jamStoneIsInfo02 = true;
        }

        if (JY_ItemDebug.instance.debug_JamStoneItem == 2 && jamStoneIsInfo01 == false && jamStoneIsInfo02 == true)
        {
            jamStoneInfo02.SetActive(false);
            jamStoneInfo03.SetActive(true);
            jamStoneIsInfo02 = false;
        }

        //Bottle Item Info
        if (JY_ItemDebug.instance.debug_BottleItem == 1 && bottleIsInfo01 == true && bottleIsInfo02 == false && bottleIsInfo03 == false)
        {
            bottleInfo01.SetActive(false);
            bottleInfo02.SetActive(true);
            bottleIsInfo01 = false;
            bottleIsInfo02 = true;
        }

        if (JY_ItemDebug.instance.debug_BottleItem == 2 && bottleIsInfo01 == false && bottleIsInfo02 == true && bottleIsInfo03 == false)
        {
            bottleInfo02.SetActive(false);
            bottleInfo03.SetActive(true);
            bottleIsInfo02 = false;
            bottleIsInfo03 = true;
        }

        if (JY_ItemDebug.instance.debug_BottleItem == 3 && bottleIsInfo01 == false && bottleIsInfo02 == false && bottleIsInfo03 == true)
        {
            bottleInfo03.SetActive(false);
            bottleInfo04.SetActive(true);
            bottleIsInfo03 = false;
        }
    }
}
