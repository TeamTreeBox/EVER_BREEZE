using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Audio : MonoBehaviour
{
    //--------------------------------Sound
    public GameObject quest01;
    private AudioSource audioSource01;
    private AudioSource audioSource02;

    public GameObject quest02;
    private AudioSource audioSource03;

    public GameObject quest03;
    private AudioSource audioSource04;

    //--------------------------------BGM
    public GameObject bagicBGM;
    private AudioSource audioSourceBGM00;

    public GameObject quest01_BGM;
    private AudioSource audioSourceBGM01;

    public GameObject quest02_BGM;
    private AudioSource audioSourceBGM02;

    public GameObject quest03_BGM;
    private AudioSource audioSourceBGM03;

    public GameObject ending_BGM;
    private AudioSource audioSourceBGM04;

    void Start()
    {
        //--------------------------------Sound
        quest01.gameObject.SetActive(false);
        audioSource01 = quest01.transform.GetChild(0).GetComponent<AudioSource>();
        audioSource02 = quest01.transform.GetChild(1).GetComponent<AudioSource>();

        quest02.gameObject.SetActive(false);
        audioSource03 = quest01.transform.GetChild(0).GetComponent<AudioSource>();

        quest03.gameObject.SetActive(false);
        audioSource04 = quest01.transform.GetChild(0).GetComponent<AudioSource>();

        //--------------------------------BGM
        bagicBGM.gameObject.SetActive(true); // ù BGM
        audioSourceBGM00 = bagicBGM.transform.GetChild(0).GetComponent<AudioSource>();
        StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM00, 10.0f, 0.3f));

        quest01_BGM.gameObject.SetActive(false);
        audioSource01 = quest01_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        quest02_BGM.gameObject.SetActive(false);
        audioSourceBGM02 = quest02_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        quest03_BGM.gameObject.SetActive(false);
        audioSourceBGM03 = quest03_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        ending_BGM.gameObject.SetActive(false); //Ending
        audioSourceBGM04 = ending_BGM.transform.GetChild(0).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------Sound
        //Quest01 Start
        if (JY_AudioManager.instance.debug_Audio == 1)
        {
            quest01.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSource01, 3.0f, 0.3f));
            StartCoroutine(JY_Audio.StartFadeIn(audioSource02, 3.0f, 0.3f));
        }

        //Quest01 Bird Fly
        if (JY_AudioManager.instance.debug_Audio == 2)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSource01, 3.0f, 0.0f));
            //quest01.gameObject.SetActive(false);
        }

        //Quest01 All Clear
        if (JY_AudioManager.instance.debug_Audio == 3)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSource02, 3.0f, 0.0f));
            //quest01.gameObject.SetActive(false);
        }

        //Quest02 Start
        if (JY_AudioManager.instance.debug_Audio == 4)
        {
            quest01.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSource01, 3.0f, 0.3f));
        }

        //--------------------------------BGM
        //Quest01 Start
        if (JY_AudioManager.instance.debug_BGM == 1)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSourceBGM00, 3.0f, 0.0f));
            quest01_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM01, 3.0f, 0.3f));
        }
        //Quest02 Start
        if (JY_AudioManager.instance.debug_BGM == 2)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSourceBGM01, 3.0f, 0.0f));
            quest02_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM02, 3.0f, 0.3f));
        }
        //Quest03 Start
        if (JY_AudioManager.instance.debug_BGM == 3)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSourceBGM02, 3.0f, 0.0f));
            quest03_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM03, 3.0f, 0.3f));
        }

        //Ending Start
        if (JY_AudioManager.instance.debug_BGM == 4)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSourceBGM03, 3.0f, 0.0f));
            ending_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM04, 3.0f, 0.3f));
        }
    }
    public static IEnumerator StartFadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator StartFadeOut(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
