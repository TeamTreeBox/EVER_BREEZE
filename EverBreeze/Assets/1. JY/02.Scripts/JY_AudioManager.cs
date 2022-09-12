using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JY_AudioManager : MonoBehaviour
{
    public static JY_AudioManager instance = null;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }

    //public AudioClip defaultAudio;
    //public AudioClip quest01Audio;
    //private AudioSource track01, track02;
    //public bool isPlayingTrack01;

    public int debug_Audio = 0;
    public int debug_BGM = 0;


    void Start()
    {
        debug_BGM = 0;
    }

    //디버그 버튼 클릭
    /*public void Debug_Audio()
    {
        debug_Audio++;
    }*/
}
