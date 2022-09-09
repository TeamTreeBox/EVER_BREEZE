using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_ItemDebug : MonoBehaviour
{
    public static JY_ItemDebug instance = null;

    private void Awake()
    {
        instance = this;
    }

    public int debug_JamStoneItem = 0;
    public int debug_BottleItem = 0;

    //JamStone 디버그 버튼 클릭
    public void Debug_JamStoneItem()
    {
        debug_JamStoneItem++;
    }

    //Bottle 디버그 버튼 클릭
    public void Debug_BottleItem()
    {
        debug_BottleItem++;
    }
}
