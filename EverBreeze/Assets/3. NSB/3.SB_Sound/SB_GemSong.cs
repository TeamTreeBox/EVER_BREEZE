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

    void Start()
    {
        SecondSong_vfx.SetActive(false);
        SecondJam_vfx.SetActive(false);
        SecondSong.GetComponent<AudioSource>().volume = 0;
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
   
            FirstSong_vfx.SetActive(false);
            FirstJam_vfx.SetActive(true);
            SecondSong_vfx.SetActive(true);
            Destroy(this.gameObject, 1f);
        }
        else if (other.tag =="JamStone" && istouched==true )
        {
  
            SecondSong_vfx.SetActive(false);
            SecondJam_vfx.SetActive(true);
            Destroy(this.gameObject, 1f);
            RenderSettings.fog = false;
        }
    }


}
