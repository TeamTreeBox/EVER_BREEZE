using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_AudioSwap01 : MonoBehaviour
{
    public AudioClip newTrack;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player") && JY_AudioManager.instance.debug_BGM == 1)
        {
            JY_AudioManager.instance.SwapTrack(newTrack);
            JY_AudioManager.instance.isPlayingTrack01 = true;
            JY_AudioManager.instance.debug_BGM = 0;
        }*/
    }
}
