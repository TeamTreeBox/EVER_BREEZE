using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
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
        PlayerAudio.GetComponent<AudioListener>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        PlayerAudio.GetComponent<AudioListener>().enabled = true;
    }
}
