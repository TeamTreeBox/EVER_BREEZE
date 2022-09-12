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

    public AudioClip defaultAudio;
    public AudioClip quest01Audio;
    private AudioSource track01, track02;
    public bool isPlayingTrack01;

    public int debug_Audio = 0;
    public int debug_BGM = 0;


    void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track01.clip = defaultAudio;
        track02 = gameObject.AddComponent<AudioSource>();
        //track02.clip = quest01Audio;
        isPlayingTrack01 = true;

        debug_BGM = 0;

        SwapTrack(defaultAudio);
    }

    public void SwapTrack(AudioClip newClip)
    {
        StopCoroutine(FadeTrack(newClip));

        StopAllCoroutines();
        StartCoroutine(FadeTrack(newClip));
    }

    public void ReturnToDefault()
    {
        SwapTrack(defaultAudio);
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.5f;
        float timeElapsed = 0f;

        if (isPlayingTrack01 == true && debug_BGM == 0)
        {
            track02.clip = newClip;
            track02.Play();

            while (timeElapsed < timeToFade)
            {
                track02.volume = Mathf.Lerp(0, 1f, timeElapsed / timeToFade);
                track01.volume = Mathf.Lerp(1f, 0, timeElapsed / timeToFade);
                yield return null;
                timeElapsed += Time.deltaTime;
            }
            track01.Stop();
            isPlayingTrack01 = !isPlayingTrack01;
        }
        if (isPlayingTrack01 == false && debug_BGM == 1)
        {
            track01.clip = newClip;
            track01.Play();

            while (timeElapsed < timeToFade)
            {
                track01.volume = Mathf.Lerp(0, 1f, timeElapsed / timeToFade);
                track02.volume = Mathf.Lerp(1f, 0, timeElapsed / timeToFade);
                yield return null;
                timeElapsed += Time.deltaTime;
            }
            track02.Stop();
            isPlayingTrack01 = true;
        }
    }


    //디버그 버튼 클릭
    /*public void Debug_Audio()
    {
        debug_Audio++;
    }*/
}
