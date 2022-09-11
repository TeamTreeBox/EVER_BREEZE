using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;


public class TeleportAudioControl : MonoBehaviour
{
    public GameObject PlayerAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            PlayerAudio.GetComponent<AudioListener>().enabled = false;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            StartCoroutine(AudioOff());
        }
    }
    IEnumerator AudioOff()
    {
        yield return new WaitForSeconds(1f);
        PlayerAudio.GetComponent<AudioListener>().enabled = true;
        AudioListener.volume = 0f;
        for (float f = 0f; f < 1f; f += 0.04f)
        {
            AudioListener.volume = f;
            yield return null;
        }

    }
}
