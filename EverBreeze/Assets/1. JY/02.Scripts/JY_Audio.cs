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
        //Quest01
        if (JY_AudioManager.instance.debug_Audio == 1)
        {
            quest01.gameObject.SetActive(true);
            StartCoroutine(JY_Audio.StartFade(audioSource01, 10.0f, 3.0f));
            StartCoroutine(JY_Audio.StartFade(audioSource02, 10.0f, 3.0f));
        }
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
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
