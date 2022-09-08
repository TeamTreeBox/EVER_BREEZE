using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public static PageManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    //public GameObject[] bookPagesOri;

    public int debug_StageClear = 0;

    private GameObject[] material;
    void Start()
    {
    }

    //디버그 버튼 클릭
    public void Debug_StageClear()
    {
        debug_StageClear++;

        /*if (debug_StageClear == 1)
        else if (debug_StageClear == 2) AutoSave.instance.gameData.isClear_2 = true;
        else if (debug_StageClear == 3) AutoSave.instance.gameData.isClear_3 = true;
        else if (debug_StageClear == 4) AutoSave.instance.gameData.isClear_4 = true;
        else if (debug_StageClear == 5) AutoSave.instance.gameData.isClear_5 = true;*/
    }
}
