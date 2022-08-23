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
    public GameObject itemSpwaner;
    GameObject gemPrefeb;

    public void SpwanJemStone()
    {
        if(gemPrefeb == null)
        {
            gemPrefeb = Instantiate(gemStone);
            gemPrefeb.transform.position = itemSpwaner.transform.position;
        }
    }


}