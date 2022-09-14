using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_GemSongA : MonoBehaviour
{
    public static SB_GemSongA instance;
    public bool istouched = false;
    public GameObject FirstSong_vfx;
    public GameObject FirstJam_vfx;
    public GameObject TriggerSound1;
    public GameObject GemSongB;

    void Start()
    {
        TriggerSound1.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag=="JamStone" )
        {
            JY_ItemDebug.instance.debug_JamStoneItem = 1;
            TriggerSound1.SetActive(true);
            FirstSong_vfx.SetActive(false);
            FirstJam_vfx.SetActive(true);
            istouched = true;
            GemSongB.SetActive(true);
            this.gameObject.SetActive(false);
        }
      
    }


}
