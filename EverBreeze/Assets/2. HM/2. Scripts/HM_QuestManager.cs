using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HM_QuestManager : MonoBehaviour
{
    public static HM_QuestManager instance;

    public GameObject Trigger_VFX;

    public bool isTutorial_Clear = false;
    public bool isQuest_1_Clear = false;
    public bool isQuest_2_Clear = false;
    public bool isQuest_3_Clear = false;

    public bool isQuest2_Clearing = false;

    public GameObject bookIcon_UI;
    CanvasGroup bookAlpha;

    //public GameObject block_1;
    //public GameObject block_2;
    //public GameObject block_3;
    //public GameObject block_4;

    private void Awake()
    {
        instance = this;
        bookAlpha = bookIcon_UI.GetComponent<CanvasGroup>();
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
        //Trigger_VFX.SetActive(false);
        HM_FoxSpoke.instacne.SelectNum_Talk(0);
        isTutorial_Clear = true;

        yield return new WaitForSeconds(1f);
        //Trigger_VFX.SetActive(true);

        BookIconPopUP();
        PageManager.instance.debug_StageClear = 1;
    }

    IEnumerator FirstQuestExit()
    {
        //Trigger_VFX.SetActive(false);
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
        //Trigger_VFX.SetActive(true);

        SB_MapManager.instance.FirstChange_Spring();
        //BookIconPopUP();
    }

    IEnumerator SecondQuestClearing()
    {
        if (isQuest2_Clearing == true)
        {
            HM_FoxSpoke.instacne.SelectNum_Talk(4);

            HM_RayGrab.instance.NullGrabable();
            HM_RayGrab.instance.isGrabOn = false;
            BookIconPopUP();
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
        BookIconPopUP();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WaterBall" && isQuest_1_Clear == false && isTutorial_Clear == true)
        {
            StartCoru(1);
            Destroy(other.gameObject.transform.GetChild(2).gameObject);
            Destroy(other.gameObject);
        }

        else if (other.tag == "Branch" && isQuest_1_Clear == true)
        {
            StartCoru(2);
            Destroy(other.gameObject);
            print("Branch");
        }

        if (other.tag == "Player" && isTutorial_Clear == false)
        {
            StartCoroutine(Tutorial());
        }
    }

    public void BookIconPopUP()
    {
        StartCoroutine(BookIconUIActive());
    }

    IEnumerator BookIconUIActive()
    {
        bookIcon_UI.SetActive(true);

        bookAlpha.alpha = 1;

        for (float i = 1f; i > 0.5f; i -= 0.05f)
        {
            bookAlpha.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }

        for (float i = 0.5f; i <= 1f; i += 0.05f)
        {
            bookAlpha.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);

        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            bookAlpha.alpha = i;
            yield return new WaitForSeconds(0.03f);
        }

        bookIcon_UI.SetActive(false);

    }
}
