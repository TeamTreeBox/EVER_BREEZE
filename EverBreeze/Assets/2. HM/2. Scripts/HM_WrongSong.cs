using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_WrongSong : MonoBehaviour
{
    public GameObject vfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JamStone")
        {
            ShowVFXandDestory();
        }
    }

    void ShowVFXandDestory()
    {
        vfx.SetActive(true);
    }
}
