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

    //����� ��ư Ŭ��
    public void Debug_StageClear()
    {
        debug_Item++;
    }
}
