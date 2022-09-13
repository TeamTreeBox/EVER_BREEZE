using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_Fountain : MonoBehaviour
{
    public GameObject WaterBall;
    private AudioSource waterShake;
    public AudioSource waterUp;
    public AudioSource waterSfx01;
    public AudioSource waterSfx02;

    private void Start()
    {
        waterShake = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider  other)
    {
        if(other.tag == "Player_Hand")
        {
            waterShake.Play();
            if (WaterBall.gameObject != null)
            WaterBall.GetComponent<HM_WaterQuest>().CristalCoroutine();
            Invoke("WaterUp", 0.0f);
            Invoke("WaterSfx01", 0.8f);
            Invoke("WaterSfx02", 3.0f);
        }    
    }

    void WaterUp()
    {
        waterUp.Play();
    }

    void WaterSfx01()
    {
        waterSfx01.Play();
    }

    void WaterSfx02()
    {
        waterSfx02.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player_Hand")
        {
            StartCoroutine(JY_Audio.StartFadeOut(waterShake, 1.0f, 0.0f));
        }
    }

    public static IEnumerator StartFadeOut(AudioSource audioSource, float duration, float targetVolume)
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
