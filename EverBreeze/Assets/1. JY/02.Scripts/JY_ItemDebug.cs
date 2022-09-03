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

    public int debug_Item = 0;

    //디버그 버튼 클릭
    public void Debug_StageClear()
    {
        debug_Item++;
    }
}
