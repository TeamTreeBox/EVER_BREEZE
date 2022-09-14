using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_GemSong : MonoBehaviour
{
    bool istouched = false;
    public GameObject FirstSong_vfx;
    public GameObject FirstJam_vfx;
    public GameObject SecondSong_vfx;
    public GameObject SecondJam_vfx;
    public GameObject SecondSong;
    public GameObject TriggerSound1;
    public GameObject TriggerSound2;

    void Start()
    {
        SecondSong_vfx.SetActive(false);
        SecondJam_vfx.SetActive(false);
        SecondSong.GetComponent<AudioSource>().volume = 0;
        TriggerSound1.SetActive(false);
        TriggerSound2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(FirstSong_vfx == false)
        {
            SecondSong.GetComponent<AudioSource>().volume += Time.deltaTime * 0.3f;
            istouched = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag=="JamStone" && istouched == false )
        {
            JY_ItemDebug.instance.debug_JamStoneItem = 1;
            TriggerSound1.SetActive(true);
            FirstSong_vfx.SetActive(false);
            FirstJam_vfx.SetActive(true);
            SecondSong_vfx.SetActive(true);
            this.gameObject.SetActive(false);

        }
        if (other.tag =="JamStone" && istouched==true )
        {
            JY_ItemDebug.instance.debug_JamStoneItem = 2;
            TriggerSound2.SetActive(true);
            SecondSong_vfx.SetActive(false);
            SecondJam_vfx.SetActive(true);
            Destroy(this.gameObject, 1f);
            RenderSettings.fog = false;
        }
    }


}
