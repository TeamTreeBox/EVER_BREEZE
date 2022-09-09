using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_ItemSpawner : MonoBehaviour
{
    public static HM_ItemSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject gemStone;
    public GameObject JingleBell;
    public GameObject Bottle;

    public GameObject itemSpwaner;
    bool gemPrefeb;
    bool jingle;
    bool isBranch;
    bool isBottle;

    public void SpwanJemStone()
    {
        if(gemPrefeb == false)
        {
            gemStone.transform.position = itemSpwaner.transform.position;
            gemStone.SetActive(true);
            gemPrefeb = true;
        }
    }


    public void SpwanJingleBell()
    {
        if(jingle == false)
        {
            JingleBell.transform.position = itemSpwaner.transform.position;
            JingleBell.SetActive(true);
            jingle = true;
        }
    }

    public void SpwanBottle()
    {
        if(isBottle == false)
        {
            Bottle.transform.position = itemSpwaner.transform.position;
            Bottle.SetActive(true);
            isBottle = true;
        }
    }
}
