using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_RightSong : MonoBehaviour
{
    bool isTouched = false;
    public GameObject vfx;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "JamStone")
        {
            ShowVFXandDestory();
        }
    }

    void ShowVFXandDestory()
    {
        vfx.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
