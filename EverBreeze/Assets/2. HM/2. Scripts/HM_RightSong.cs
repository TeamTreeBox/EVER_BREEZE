using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_RightSong : MonoBehaviour
{
    bool isTouched = false;
    public GameObject start_vfx;
    public GameObject jam_vfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JamStone")
        {
            start_vfx.SetActive(false);
            ShowVFXandDestory();
        }
    }

    void ShowVFXandDestory()
    {
        jam_vfx.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
