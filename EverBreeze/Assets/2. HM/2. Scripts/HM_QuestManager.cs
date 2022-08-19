using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_QuestManager : MonoBehaviour
{
    public bool isQuest_1_Clear = false;
    public bool isQuest_2_Clear = false;
    public bool isQuest_3_Clear = false;

    public GameObject block_1;
    public GameObject block_2;
    public GameObject block_3;
    public GameObject block_4;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterBall")
        {
            isQuest_1_Clear = true;
            block_2.SetActive(false);
            block_1.SetActive(true);
            HM_TreeManager.instance.QuestEventTrigger(1);

            Destroy(other.gameObject);

            HM_ItemSpawner.instance.SpwanJemStone();
            HM_RayGrab.instance.NullGrabable();
            HM_RayGrab.instance.isGrabOn = false;
        }
        else if(isQuest_1_Clear == true && other.tag == "JamStone")
        {
            isQuest_2_Clear = true;
            block_3.SetActive(true);
            block_2.SetActive(false);

            HM_TreeManager.instance.QuestEventTrigger(2);

            Destroy(other.gameObject);
            HM_RayGrab.instance.NullGrabable();
            HM_RayGrab.instance.isGrabOn = false;
        }
    }
}
