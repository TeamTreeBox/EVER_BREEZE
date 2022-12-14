using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HM_RightSong : MonoBehaviour
{
    bool isTouched = false;
    public GameObject start_vfx;
    public GameObject jam_vfx;
    public GameObject SecondAudio;

    private void Start()
    {
        SecondAudio.GetComponent<AudioSource>().volume =0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JamStone")
        {
            start_vfx.SetActive(false);
            SecondAudio.GetComponent<AudioSource>().volume +=Time.deltaTime*0.1f;
            ShowVFXandDestory();
        }
    }

    void ShowVFXandDestory()
    {
        jam_vfx.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
