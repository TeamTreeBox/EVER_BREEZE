using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_QuestManager : MonoBehaviour
{
    public static HM_QuestManager instance;
    public GameObject Trigger_VFX;

    private void Start()
    {
        instance = this;
    }
    public bool isTutorial_Clear = false;
    public bool isQuest_1_Clear = false;
    public bool isQuest_2_Clear = false;
    public bool isQuest_3_Clear = false;

    public bool isQuest2_Clearing = false;

    //public GameObject block_1;
    //public GameObject block_2;
    //public GameObject block_3;
    //public GameObject block_4;

    private void Update()
    {
       
    }

    public void StartCoru(int num)
    {
        switch (num)
        {
            case 1:
                StartCoroutine(FirstQuestExit());
                break;
            case 2:
                StartCoroutine(SecondQuestClearing());
                break;
            case 3:
                StartCoroutine(SecondQuestExit());
                break;
        }
    }

    IEnumerator Tutorial()
    {
        Trigger_VFX.SetActive(false);
        HM_FoxSpoke.instacne.SelectNum_Talk(0);
        isTutorial_Clear = true;

        yield return new WaitForSeconds(10f);
        Trigger_VFX.SetActive(true);

    }

    IEnumerator FirstQuestExit()
    {
        Trigger_VFX.SetActive(false);
        HM_FoxSpoke.instacne.SelectNum_Talk(2);
        isQuest_1_Clear = true;
        //block_2.SetActive(false);
        //block_1.SetActive(true);
        HM_TreeManager.instance.QuestEventTrigger(1);

       
        HM_RayGrab.instance.NullGrabable();
        HM_RayGrab.instance.isGrabOn = false;

        yield return new WaitForSeconds(1f);
        HM_FoxAI.instane.QuestComplete();
        yield return new WaitForSeconds(9f);
        Trigger_VFX.SetActive(true);

        SB_MapManager.instance.FirstChange_Spring();
    }

    IEnumerator SecondQuestClearing()
    {
        if (isQuest2_Clearing == true)
        {
            Trigger_VFX.SetActive(false);
            HM_FoxSpoke.instacne.SelectNum_Talk(4);
           
            HM_RayGrab.instance.NullGrabable();
            HM_RayGrab.instance.isGrabOn = false;
        }
        else
        {
            
            isQuest2_Clearing = true;
            HM_RayGrab.instance.NullGrabable();
            HM_RayGrab.instance.isGrabOn = false;
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator SecondQuestExit()
    {
        isQuest_2_Clear = true;
        //block_2.SetActive(true);
        //block_3.SetActive(false);
        HM_FoxSpoke.instacne.SelectNum_Talk(5);
        HM_TreeManager.instance.QuestEventTrigger(2);
        
        HM_RayGrab.instance.NullGrabable();
        HM_RayGrab.instance.isGrabOn = false;

        yield return new WaitForSeconds(1f);
        HM_FoxAI.instane.QuestComplete();
        yield return new WaitForSeconds(9f);
        Trigger_VFX.SetActive(true);

        SB_MapManager.instance.SecondChange_Spring();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterBall" && isQuest_1_Clear == false && isTutorial_Clear == true)
        {
            StartCoru(1);
            Destroy(other.gameObject.transform.GetChild(2).gameObject);
            Destroy(other.gameObject);
        }
        
        else if(other.tag == "Branch" && isQuest_1_Clear == true)
        {
            StartCoru(2);
            Destroy(other.gameObject);
            print("Branch");
        }

        if(other.tag == "Player" && isTutorial_Clear == false)
        {
            StartCoroutine(Tutorial());
        }
    }
}
