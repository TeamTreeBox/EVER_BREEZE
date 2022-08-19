using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_PCQuestMg : MonoBehaviour
{
    public bool isQuest_1_Clear = false;
    public bool isQuest_2_Clear = false;
    public bool isQuest_3_Clear = false;

    public GameObject block_1;
    public GameObject block_2;
    public GameObject block_3;
    public GameObject block_4;

    public GameObject gemStone;

    HM_PCJam pcJam;

    private void Start()
    {
        pcJam = gemStone.transform.GetChild(0).gameObject.GetComponent<HM_PCJam>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WaterBall")
        {
            isQuest_1_Clear = true;
            block_2.SetActive(false);
            block_1.SetActive(true);
            HM_TreeManager.instance.QuestEventTrigger(1);

            Destroy(other.gameObject);

            HM_ItemSpawner.instance.SpwanJemStone();
            
        }
        else if (isQuest_1_Clear == true && other.tag == "JamStone" && pcJam.isTouchEnough == true)
        {
            isQuest_2_Clear = true;
            block_3.SetActive(true);
            block_2.SetActive(false);

            HM_TreeManager.instance.QuestEventTrigger(2);

            Destroy(other.gameObject);
           
        }
    }
}
