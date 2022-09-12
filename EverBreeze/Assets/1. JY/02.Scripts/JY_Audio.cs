using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Audio : MonoBehaviour
{
    public GameObject quest01;
    private AudioSource audioSource01;
    private AudioSource audioSource02;

    void Start()
    {
        quest01.gameObject.SetActive(false);
        audioSource01 = quest01.transform.GetChild(0).GetComponent<AudioSource>();
        audioSource02 = quest01.transform.GetChild(1).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Quest01 Start
        if (JY_AudioManager.instance.debug_Audio == 1)
        {
            quest01.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFadeIn(audioSource01, 10.0f, 0.3f));
            StartCoroutine(JY_Audio.StartFadeIn(audioSource02, 10.0f, 0.3f));
        }

        //Quest01 Clear
        if (JY_AudioManager.instance.debug_Audio == 2)
        {
            StartCoroutine(JY_Audio.StartFadeOut(audioSource01, 3.0f, 0.0f));
            StartCoroutine(JY_Audio.StartFadeOut(audioSource02, 3.0f, 0.0f));
            //quest01.gameObject.SetActive(false);
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
