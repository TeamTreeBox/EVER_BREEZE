using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_BranchSound : MonoBehaviour
{
    public AudioClip[] FootSound;
    AudioSource AS;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
                RandomPlay();
        }
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

    void RandomPlay()
    {
        AS.clip = FootSound[Random.Range(0, FootSound.Length)];
        AS.Play();
    }
}
