using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HM_QuestManager : MonoBehaviour
{
    public static HM_QuestManager instance;

    
    public GameObject Trigger_VFX;
   [SerializeField]
    public bool isTutorial_Clear = false;
    public bool isQuest_1_Clear = false;
    public bool isQuest_2_Clear = false;
    public bool isQuest_3_Clear = false;
    
    public bool isQuest2_Clearing = false;

    public bool isBranchOn = false;
    public bool isJamStoneOn = false;

    public GameObject UICanvas;
    public GameObject bookIcon_UI;
    public GameObject QuestTriggerUI;
    public GameObject ChangeSkyBox;
    public GameObject PlayerParticle;
    CanvasGroup bookAlpha;

    public GameObject Snow;

    public GameObject Stage1_Collidor;
    public GameObject Stage2_Collidor;
    public GameObject Stage3_Collidor;

    public GameObject Quest2;
    public GameObject[] PlayerInventory;
    GameObject InPlayerSlot_Item = null;
    string tagname;

    bool isCheckOnce_1_2 = false;
    bool isCheckOnce_6_2 = false;


    //public GameObject block_1;
    //public GameObject block_2;
    //public GameObject block_3;
    //public GameObject block_4;

    private void Awake()
    {
        instance = this;
        bookAlpha = UICanvas.GetComponent<CanvasGroup>();
        Snow.SetActive(true);
       
    }

    private void Update()
    {
        //print("isJamStone = " + isJamStoneOn);
        //print("isBranch = " + isBranchOn);
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
            case 4:
                StartCoroutine(ThirdQuestExit());
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
        Stage1_Collidor.SetActive(false);

    }

    IEnumerator FirstQuestExit()
    {
        //Trigger_VFX.SetActive(false);
        HM_FoxSpoke.instacne.SelectNum_Talk(2);
        JY_AudioManager.instance.debug_Audio = 3;
        isQuest_1_Clear = true;
        //block_2.SetActive(false);
        //block_1.SetActive(true);
        HM_TreeManager.instance.QuestEventTrigger(1);
        

        JY_RayGrab.instance.NullGrabable();
        JY_RayGrab.instance.isGrabOn = false;

        yield return new WaitForSeconds(1f);
        HM_FoxAI.instane.QuestComplete();
        yield return new WaitForSeconds(9f);
        //Trigger_VFX.SetActive(true);

        PlayerParticle.SetActive(true);
        SB_MapManager.instance.FirstChange_Spring();
        SB_MapManager.instance.FirstChange_Main();
      
        GameObject.Find("");
        Quest2.SetActive(true);
        Snow.SetActive(false);
        Stage2_Collidor.SetActive(false);
        Stage1_Collidor.SetActive(true);
        yield return new WaitForSeconds(2f);
        PlayerParticle.SetActive(false);
        //BookIconPopUP();
    }
   

    IEnumerator SecondQuestClearing()
    {
        if(isBranchOn == true && isJamStoneOn == true)
        {
            HM_FoxSpoke.instacne.SelectNum_Talk(4);

            JY_RayGrab.instance.NullGrabable();
            JY_RayGrab.instance.isGrabOn = false;
            BookIconPopUP();
        }
        else if(isBranchOn == true || isJamStoneOn == true)
        {
            JY_RayGrab.instance.NullGrabable();
            JY_RayGrab.instance.isGrabOn = false;
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

        JY_RayGrab.instance.NullGrabable();
        JY_RayGrab.instance.isGrabOn = false;

        yield return new WaitForSeconds(1f);
        HM_FoxAI.instane.QuestComplete();
        yield return new WaitForSeconds(9f);
        //Trigger_VFX.SetActive(true);

        PlayerParticle.SetActive(true);
        SB_MapManager.instance.SecondChange_Spring();
        SB_MapManager.instance.SecondChange_Main();
        Stage3_Collidor.SetActive(false);
        Stage2_Collidor.SetActive(true);
        yield return new WaitForSeconds(2f);
        PlayerParticle.SetActive(false);
        //BookIconPopUP();
    }

    IEnumerator ThirdQuestExit()
    {

        isQuest_3_Clear = true;
        HM_FoxSpoke.instacne.SelectNum_Talk(7);
        HM_TreeManager.instance.QuestEventTrigger(3);

        JY_RayGrab.instance.NullGrabable();
        JY_RayGrab.instance.isGrabOn = false;

        HM_FoxAI.instane.QuestComplete();

        yield return new WaitForSeconds(1f);
        PlayerParticle.SetActive(true);
        SB_MapManager.instance.ThirdChange_Spring();
        SB_MapManager.instance.ThirdChange_Main();

        ChangeSkyBox.GetComponent<HM_SkyboxTrigger>().ChangeSkyDay();
        Stage3_Collidor.SetActive(true);
        yield return new WaitForSeconds(2f);
        PlayerParticle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterBall" && isQuest_1_Clear == false && isTutorial_Clear == true && other.gameObject.GetComponent<JY_ItemInfo>().state == ItemState.Grab)
        {
            StartCoru(1);
            Destroy(other.gameObject.transform.GetChild(2).gameObject);
            Destroy(other.gameObject);
        }
       
        else if (other.tag == "Branch" && isQuest_1_Clear == true && other.gameObject.GetComponent<JY_ItemInfo>().state == ItemState.Grab)
        {
            isBranchOn = true;
            StartCoru(2);
            Destroy(other.gameObject);
            print("Branch");
        }
        else if(other.tag == "Bottle" && isQuest_2_Clear == true && other.gameObject.GetComponentInChildren<SB_ButterflyQuest>().isCatchAll == true)
        {
           
            StartCoru(4);
            Destroy(other.gameObject);
            print("Bottle");
        }
            if (other.tag == "Player" && isTutorial_Clear == false)
            {
            print("Æ©Åä¸®¾ó");
            StartCoroutine(Tutorial());
            }
            else if(other.tag == "Player" && isTutorial_Clear == true)
            {
            StartCoroutine(Check_Player_Invetory());
            }
            
    }

    IEnumerator Check_Player_Invetory()
    {
         for(int i = 0; i < PlayerInventory.Length; i++)
        {
            if(PlayerInventory[i].transform.childCount != 0)
            {
                //InPlayerSlot_Item = PlayerInventory[i].transform.GetChild(0).gameObject;
                tagname = PlayerInventory[i].transform.GetChild(0).gameObject.tag;
                print(tagname);
            }
        }

         if(tagname == "WaterBall" && isCheckOnce_1_2 == false)
        {
            isCheckOnce_1_2 = true;
            print("FoxTalk_1_2");
            HM_FoxSpoke.instacne.Fox_Talk_1_2_Func();
        }
         else if(tagname == "Bottle" && isCheckOnce_6_2 == false)
        {
            isCheckOnce_6_2 = true;
            print("FoxTalk_6_2");
            HM_FoxSpoke.instacne.Fox_Talk_6_2_Func();
        }

        yield return new WaitForEndOfFrame();
    }

    public void BookIconPopUP()
    {
        StartCoroutine(BookIconUIActive());
    }

    public void QuestTriggerIconPopUp()
    {
        StartCoroutine(QuestTriggerUIActive());
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

    IEnumerator QuestTriggerUIActive()
    {
        QuestTriggerUI.SetActive(true);
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

        QuestTriggerUI.SetActive(false);
    }
}
