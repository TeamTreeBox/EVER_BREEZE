using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Audio : MonoBehaviour
{
    public static JY_Audio instance = null;

    private void Awake()
    {
        instance = this;
    }
    //--------------------------------Sound
    public GameObject quest01;
    private AudioSource audioSource01;
    private AudioSource audioSource02;
    private AudioSource audioSource03;

    public GameObject quest02;
    private AudioSource audioSource04;

    public GameObject quest03;
    private AudioSource audioSource05;

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

    //--------------------------------Tree
    public GameObject tree01;
    private AudioSource audioSourcetree01;

    public GameObject tree02;
    private AudioSource audioSourcetree02;

    public GameObject tree03;
    private AudioSource audioSourcetree03;

    void Start()
    {
        //--------------------------------Sound
        quest01.gameObject.SetActive(false);
        audioSource01 = quest01.transform.GetChild(0).GetComponent<AudioSource>();
        audioSource02 = quest01.transform.GetChild(1).GetComponent<AudioSource>();

        quest02.gameObject.SetActive(false);
        audioSource04 = quest02.transform.GetChild(0).GetComponent<AudioSource>();

        quest03.gameObject.SetActive(false);
        audioSource05 = quest03.transform.GetChild(0).GetComponent<AudioSource>();

        //--------------------------------BGM
        bagicBGM.gameObject.SetActive(true); // ù BGM
        audioSourceBGM00 = bagicBGM.transform.GetChild(0).GetComponent<AudioSource>();
        StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM00, 10.0f, 0.3f));

        quest01_BGM.gameObject.SetActive(false);
        audioSourceBGM01 = quest01_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        quest02_BGM.gameObject.SetActive(false);
        audioSourceBGM02 = quest02_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        quest03_BGM.gameObject.SetActive(false);
        audioSourceBGM03 = quest03_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        ending_BGM.gameObject.SetActive(false); //Ending
        audioSourceBGM04 = ending_BGM.transform.GetChild(0).GetComponent<AudioSource>();

        //--------------------------------Tree
        tree01.gameObject.SetActive(false);
        audioSourcetree01 = tree01.transform.GetChild(0).GetComponent<AudioSource>();

        tree02.gameObject.SetActive(false);
        audioSourcetree02 = tree02.transform.GetChild(0).GetComponent<AudioSource>();

        tree03.gameObject.SetActive(false);
        audioSourcetree03 = tree03.transform.GetChild(0).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------Sound
        //Quest01 Start
        if (JY_AudioManager.instance.debug_Audio == 1)
        {
            quest01.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSource01, 3.0f, 0.2f));
            StartCoroutine(JY_Audio.StartFadeIn(audioSource02, 3.0f, 0.2f));
        }

        //Quest01 Bird Fly
        if (JY_AudioManager.instance.debug_Audio == 2)
        {
            //StartCoroutine(JY_Audio.StartFadeIn(audioSource03, 0.0f, 1.0f));
            StartCoroutine(JY_Audio.StartFadeOut(audioSource01, 2.0f, 0.0f));
        }

        //Quest01 All Clear
        if (JY_AudioManager.instance.debug_Audio == 3)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSource02, 3.0f, 0.0f));
        }

        //Quest02 Start
        if (JY_AudioManager.instance.debug_Audio == 4)
        {
            quest02.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSource04, 3.0f, 0.2f));
        }

        //Quest03 Start
        if (JY_AudioManager.instance.debug_Audio == 5)
        {
            quest03.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeOut(audioSource04, 3.0f, 0.0f));
            StartCoroutine(JY_Audio.StartFadeIn(audioSource05, 3.0f, 0.2f));
        }

        //--------------------------------BGM
        //Quest01 Start
        if (JY_AudioManager.instance.debug_BGM == 1)
        {
            StartCoroutine(JY_Audio.StartFadeOutBGM(audioSourceBGM00, 3.0f, 0.0f));
            quest01_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM01, 3.0f, 0.1f));
        }
        //Quest02 Start
        if (JY_AudioManager.instance.debug_BGM == 5)
        {
            StartCoroutine(JY_Audio.StartFadeOutBGM(audioSourceBGM01, 3.0f, 0.0f));
        }
        if (JY_AudioManager.instance.debug_BGM == 2)
        {
            quest02_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM02, 3.0f, 0.1f));
        }
        //Quest03 Start
        if (JY_AudioManager.instance.debug_BGM == 6)
        {
            StartCoroutine(JY_Audio.StartFadeOutBGM(audioSourceBGM02, 3.0f, 0.0f));
        }
        if (JY_AudioManager.instance.debug_BGM == 3)
        {
            quest03_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM03, 3.0f, 0.1f));
        }

        //Ending Start
        if (JY_AudioManager.instance.debug_BGM == 7)
        {
            StartCoroutine(JY_Audio.StartFadeOutBGM(audioSourceBGM03, 3.0f, 0.0f));
        }
        if (JY_AudioManager.instance.debug_BGM == 4)
        {
            StartCoroutine(JY_Audio.StartFadeOutTree(audioSourcetree03, 1.0f, 0.0f));
            ending_BGM.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSourceBGM04, 3.0f, 0.1f));
        }
    }

    public void Audio_Tree01()
    {
        JY_AudioManager.instance.debug_BGM = 5;

        //Tree_01
        tree01.gameObject.SetActive(true);
        StartCoroutine(JY_Audio.StartFadeIn(audioSourcetree01, 1.0f, 0.5f));
    }

    public void Audio_Tree02()
    {
        JY_AudioManager.instance.debug_BGM = 6;

        //Tree_02
        tree02.gameObject.SetActive(true);
        StartCoroutine(JY_Audio.StartFadeIn(audioSourcetree02, 1.0f, 0.5f));
    }

    public void Audio_Tree03()
    {
        JY_AudioManager.instance.debug_BGM = 7;

        //Tree_03
        tree03.gameObject.SetActive(true);
        StartCoroutine(JY_Audio.StartFadeIn(audioSourcetree03, 1.0f, 0.5f));
    }

    public static IEnumerator StartFadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = 0;
        //  audioSource.loop = true;
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
        float start = 0.2f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator StartFadeOutBGM(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = 0.1f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator StartFadeOutTree(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = 0.5f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
