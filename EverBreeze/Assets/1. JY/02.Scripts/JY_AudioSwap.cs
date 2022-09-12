using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_AudioSwap : MonoBehaviour
{
    public AudioClip newTrack;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player") && JY_AudioManager.instance.debug_BGM == 0)
        {
            JY_AudioManager.instance.SwapTrack(newTrack);
            JY_AudioManager.instance.isPlayingTrack01 = false;
            JY_AudioManager.instance.debug_BGM = 1;
        }*/
    }

}
