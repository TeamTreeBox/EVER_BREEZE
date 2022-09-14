using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_GemSongB : MonoBehaviour
{
 

    public GameObject SecondSong_vfx;
    public GameObject SecondJam_vfx;
    public GameObject SecondSong;
    public GameObject TriggerSound2;

   

    void Start()
    {
        this.gameObject.SetActive(false);
        SecondSong.GetComponent<AudioSource>().volume = 0;
        
    }
 

    // Update is called once per frame
    void Update()
    {
        if (SB_GemSongA.instance.istouched == true)
        {
            SecondSong.GetComponent<AudioSource>().volume += Time.deltaTime * 0.3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag =="JamStone" && SB_GemSongA.instance.istouched==true )
        {
            JY_ItemDebug.instance.debug_JamStoneItem = 2;
            TriggerSound2.SetActive(true);
            SecondSong_vfx.SetActive(false);
            SecondJam_vfx.SetActive(true);
            RenderSettings.fog = false;
            Destroy(this.gameObject, 1f);
           
        }
    }


}
